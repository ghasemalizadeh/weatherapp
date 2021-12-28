import { ForcastService } from 'src/Services/forcast.service';
import { LocationService } from './../../Services/location.service';
import { Component, ComponentFactoryResolver, OnInit } from '@angular/core';

@Component({
  selector: 'app-city-select',
  templateUrl: './city-select.component.html',
  styleUrls: ['./city-select.component.css']
})
export class CitySelectComponent implements OnInit {

  countries:any[];
  adminAreas:any[];
  selectedLocation:any={};
  cities:any[];
  regions:any[];
  fiveDayForcast:any;
  render=false;
 

  constructor( private locationService:LocationService, private forcastService:ForcastService) { }

  ngOnInit() {
    this.locationService.getAllRegions().subscribe(result=>
        {
          this.regions = result as any[];
          console.log(this.countries);
    });

    
  }

  onCountryChanged(){
    console.log(this.selectedLocation);
    this.adminAreas = [];
    this.cities = [];

    this.locationService.getAdminAreas(this.selectedLocation.country).subscribe(result=>
      {
        this.adminAreas = result as any[];

        const selectedArea = this.countries.find(c=>c.id == this.selectedLocation.country);
        console.log(selectedArea);
        this.cities = selectedArea.cities;
        
      });
   
  }

  onRegionChanged(){
    console.log(this.selectedLocation);
    this.adminAreas = [];
    this.cities = [];
    this.locationService.getRegionCountries(this.selectedLocation.region).subscribe(result=>
      {
        this.countries = result as any[];
      });
  }

  onAdminAreaChanged(){
    console.log(this.selectedLocation);
    this.cities = [];
    console.log(this.adminAreas);

    const selectedArea = this.adminAreas.find(c=>c.id == this.selectedLocation.adminArea);
    console.log(selectedArea);
    this.cities = selectedArea.cities;
   
  }

  onCityChanged(){
    console.log("City Changed "+this.selectedLocation);
    this.forcastService.getFiveDayForcast(this.selectedLocation.area).subscribe(result=>
      {
        this.fiveDayForcast = result;
        console.log(this.fiveDayForcast);
        this.render = true;
        console.log(this.render);
      })
  }

  onSearchClicked(){
    
    this.locationService.search(this.selectedLocation.citySearch,this.selectedLocation.country,
      this.selectedLocation.adminArea).subscribe(result=>
      {
        console.log(result);
        this.adminAreas = [];
        this.cities = [];
    
        this.locationService.getAdminAreas(this.selectedLocation.country).subscribe(result=>
          {
            this.adminAreas = result as any[];
            console.log(this.adminAreas);  
            console.log(this.selectedLocation);
           const selectedArea = this.adminAreas.find(c=>c.id == this.selectedLocation.adminArea);
           console.log(selectedArea);
           this.cities = selectedArea.cities;

          });

        
        
        

       
        
      });

  }

}
