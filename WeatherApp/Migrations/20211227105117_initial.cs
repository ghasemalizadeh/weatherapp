using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<int>(type: "int", nullable: false),
                    IconPhrase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasPrecipitation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Headline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEpochDate = table.Column<int>(type: "int", nullable: true),
                    Severity = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndEpochDate = table.Column<int>(type: "int", nullable: true),
                    MobileLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maximum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maximum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Minimum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minimum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Night",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<int>(type: "int", nullable: false),
                    IconPhrase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasPrecipitation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Night", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TimeZones",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GmtOffset = table.Column<double>(type: "float", nullable: false),
                    IsDaylightSaving = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeZones", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Temperature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinimumId = table.Column<int>(type: "int", nullable: true),
                    MaximumId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperature_Maximum_MaximumId",
                        column: x => x.MaximumId,
                        principalTable: "Maximum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Temperature_Minimum_MinimumId",
                        column: x => x.MinimumId,
                        principalTable: "Minimum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Countries_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdministrativeAreas",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    LocalizedType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministrativeAreas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdministrativeAreas_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    LocalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AdministrativeAreaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TimeZoneId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsAlias = table.Column<bool>(type: "bit", nullable: false),
                    ParentCityKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Key);
                    table.ForeignKey(
                        name: "FK_Cities_AdministrativeAreas_AdministrativeAreaId",
                        column: x => x.AdministrativeAreaId,
                        principalTable: "AdministrativeAreas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cities_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cities_TimeZones_TimeZoneId",
                        column: x => x.TimeZoneId,
                        principalTable: "TimeZones",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FiveDaysForcasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HeadlineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiveDaysForcasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FiveDaysForcasts_Cities_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Cities",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FiveDaysForcasts_Headline_HeadlineId",
                        column: x => x.HeadlineId,
                        principalTable: "Headline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyForecast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EpochDate = table.Column<int>(type: "int", nullable: false),
                    TemperatureId = table.Column<int>(type: "int", nullable: true),
                    DayId = table.Column<int>(type: "int", nullable: true),
                    NightId = table.Column<int>(type: "int", nullable: true),
                    MobileLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiveDaysForcastId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyForecast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyForecast_Day_DayId",
                        column: x => x.DayId,
                        principalTable: "Day",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyForecast_FiveDaysForcasts_FiveDaysForcastId",
                        column: x => x.FiveDaysForcastId,
                        principalTable: "FiveDaysForcasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyForecast_Night_NightId",
                        column: x => x.NightId,
                        principalTable: "Night",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyForecast_Temperature_TemperatureId",
                        column: x => x.TemperatureId,
                        principalTable: "Temperature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministrativeAreas_CountryId",
                table: "AdministrativeAreas",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_AdministrativeAreaId",
                table: "Cities",
                column: "AdministrativeAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionId",
                table: "Cities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_TimeZoneId",
                table: "Cities",
                column: "TimeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_RegionId",
                table: "Countries",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyForecast_DayId",
                table: "DailyForecast",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyForecast_FiveDaysForcastId",
                table: "DailyForecast",
                column: "FiveDaysForcastId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyForecast_NightId",
                table: "DailyForecast",
                column: "NightId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyForecast_TemperatureId",
                table: "DailyForecast",
                column: "TemperatureId");

            migrationBuilder.CreateIndex(
                name: "IX_FiveDaysForcasts_HeadlineId",
                table: "FiveDaysForcasts",
                column: "HeadlineId");

            migrationBuilder.CreateIndex(
                name: "IX_FiveDaysForcasts_LocationId",
                table: "FiveDaysForcasts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_MaximumId",
                table: "Temperature",
                column: "MaximumId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperature_MinimumId",
                table: "Temperature",
                column: "MinimumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyForecast");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "FiveDaysForcasts");

            migrationBuilder.DropTable(
                name: "Night");

            migrationBuilder.DropTable(
                name: "Temperature");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Headline");

            migrationBuilder.DropTable(
                name: "Maximum");

            migrationBuilder.DropTable(
                name: "Minimum");

            migrationBuilder.DropTable(
                name: "AdministrativeAreas");

            migrationBuilder.DropTable(
                name: "TimeZones");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
