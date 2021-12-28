import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ForcastService {

  constructor(private http:HttpClient) {

    
   }

   getFiveDayForcast(locationCode:string){
     const url = `api/forcast/5days/${locationCode}`;
     console.log(`calling url ${url}`)
     return this.http.get(url);
      
  }





}
