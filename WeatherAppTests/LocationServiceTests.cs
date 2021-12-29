using AutoMapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.ApiServices;
using WeatherApp.Dto;
using WeatherApp.MappingProfile;
using WeatherApp.Model;
using WeatherApp.Persistence;
using WeatherApp.Services;

namespace WeatherAppTests
{
    public abstract class TestWithSqlite : IDisposable
    {
        private const string InMemoryConnectionString = "Data Source=:memory:";
        private readonly SqliteConnection _connection;

        protected readonly WeatherContext DbContext;

        protected TestWithSqlite()
        {

            var options = new DbContextOptionsBuilder<WeatherContext>().UseInMemoryDatabase(databaseName: "Weather").Options;
                    
                  
            DbContext = new WeatherContext(options);
            DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }

    class LocationServiceTests
    {
        Mock<WeatherContext> mockContext;
        Mock<IWeatherApiService> mockApiService;
        IMapper mapper;
        protected  WeatherContext DbContext;

        [SetUp]
        public void Setup()
        {
           
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new LocationMappingProfile());
            });

            mapper = mapperConfig.CreateMapper();

            //Mocking db context;

            var options = new DbContextOptionsBuilder<WeatherContext>()
                      .UseInMemoryDatabase(databaseName: "Waether")
                     .Options;
            DbContext = new WeatherContext(options);
            DbContext.Database.EnsureCreated();


            //Mocking WeatherApiService
             mockApiService = new Mock<IWeatherApiService>();


        }


        [Test]
        public async Task GetAllRegions_WhenCalled_ReturnRegion()
        {
            //Arrange
           
            List<RegionDto> regions = new List<RegionDto>();
            regions.Add(new RegionDto { ID = "MED", EnglishName = "Middle East", LocalizedName = "Middle East" });
            mockApiService.Setup(m => m.GetRegions()).Returns(Task.FromResult<IEnumerable<RegionDto>>(regions));

            ILocationService ls = new LocationService(DbContext, mockApiService.Object,mapper);

            //Act
            List<RegionDto> actual = (List<RegionDto>)await ls.GetAllRegions();

            //Assert
            Assert.AreEqual(actual.Count,1);
            
           
        }

        [Test]
        public async Task GetRegionsCountries_CountriesInDb_ReturnCountries()
        {
            //Arrange
            DbContext.Regions.Add(new Region { ID = "OCN", EnglishName = "Oceania", LocalizedName = "Oceania" });
            DbContext.Countries.Add(new Country { ID = "AU", EnglishName = "Austrilia", LocalizedName = "Austrilia",RegionId = "OCN" });
            DbContext.SaveChanges();
            ILocationService ls = new LocationService(DbContext, mockApiService.Object, mapper);

            //Act
            List<CountryDto> actual = (List<CountryDto>)await ls.GetRegionConutries("OCN");

            //Assert
            Assert.AreEqual(actual[0].EnglishName, "Austrilia");

         
        }
    }
}
