import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor(private http:HttpClient) { }

  getAllCountries():any{

    return this.http.get("/api/location/allcountries");

  }

  getAllRegions():any{

    return this.http.get("/api/location/GetAllRegions");

  }

  getAdminAreas(countryCode:string):any{
  

    return this.http.get(`/api/location/GetCountryAdminAreas/${countryCode}`);

  }

  search(query:string,country:string,adminArea:string){
    console.log("search clicked")

    return this.http.get(`/api/location/search/${country}/${adminArea}/${query}`);


  }

  //

  getRegionCountries(regionCode:string):any{
  

    return this.http.get(`/api/location/GetRegionCountries/${regionCode}`);

  }
}
