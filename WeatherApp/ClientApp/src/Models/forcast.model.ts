export interface DailyForcast{
    
    minimumTemprature:string;
    maximumTemprature:string;
    date:string;
    unit: TempratureUnit;
}

export interface FiveDayForcast{
    cityName:string;
    countryName:string;
    dailyForecasts:DailyForcast[];

}

export enum TempratureUnit {
    metric = 'C',
    imperial = 'F'

}