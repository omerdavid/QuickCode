import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of, Subject, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { UserSettings } from './models/user-settings';
import { WeatherData } from './models/weatherData';
import {Cities, City} from './cities';
import {neeededUnits,Unit} from './neededUnits';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
 
  cities:City[]=Cities;
  neeededUnits:Unit[]=neeededUnits;

set title(value: string) {
    this.titleSubj$.next(value);
}
public title$:Observable<string>;
 private titleSubj$:Subject<string>=new Subject<string>();


 private _userSettings:UserSettings;

//Expose user settings by proprty 
set userSettings(value:UserSettings){
    this._userSettings=value;
    if(this.usersettingsSubj$)
    this.usersettingsSubj$.next(value);
}
get userSettings():UserSettings{
  return this.usersettingsSubj$.getValue();
}
 

 public userSettings$:Observable<UserSettings>;

 //Make behavior subject private in order to control data delegation 
 private usersettingsSubj$:BehaviorSubject<UserSettings>;

 public weatherData$:Observable<WeatherData>;
 private weahterDataSubj$:BehaviorSubject<WeatherData>=new BehaviorSubject<WeatherData>(null);

 url:string;
 

  constructor(private http:HttpClient,) {
 
    
    
    //Set default value
this._userSettings=new UserSettings();
this._userSettings.city=this.cities[0];
this._userSettings.units=this.neeededUnits[0];

this.usersettingsSubj$=new BehaviorSubject<UserSettings>(this._userSettings);

//Expose observable rather than subjects in order to control data flow from service,avoid service clients from 
    //streaming data independently 
    this.title$=this.titleSubj$.asObservable();
    this.userSettings$=this.usersettingsSubj$.asObservable();
    this.weatherData$=this.weahterDataSubj$.asObservable();
    
   }
   getCityweather(_userSettings:UserSettings):Observable<WeatherData>{
     
    if(!_userSettings||!_userSettings.city)
    return;

    this.userSettings=_userSettings;
    
     this.url=`https://api.openweathermap.org/data/2.5/weather?id=${_userSettings.city.cityId}&units=${_userSettings.units.id}&appId=2c06bae5d05d6cb24e6faa0797bb44f6`;


     return this.http.get(this.url).pipe(tap(console.log),map(({weather,main,name}:any)=>{
      
      let t=new WeatherData();
     let _weather=null;
       if(Array.isArray(weather)&&weather.length>0){
            _weather=weather[0];
       }
       t.description=_weather.description;
       t.temperture=main.temp;
       t.cityName=name;
       t.icon=_weather.icon;

       return t;
     }),tap((t:WeatherData)=>this.weahterDataSubj$.next(t))
     );
   }
   
}
