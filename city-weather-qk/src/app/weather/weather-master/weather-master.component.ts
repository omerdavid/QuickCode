import { Component, OnInit } from '@angular/core';
import { City } from '../cities';
import { UserSettings } from '../models/user-settings';
import { WeatherData } from '../models/weatherData';
import { WeatherService } from '../weather.service';

@Component({
  selector: 'app-weather-master',
  templateUrl: './weather-master.component.html',
  styleUrls: ['./weather-master.component.css']
})
export class WeatherMasterComponent implements OnInit {
  
  userSettings:UserSettings;

   constructor(public weatherSrv:WeatherService)
    {
    this.weatherSrv.title="Weather Atm";
   }
 
  ngOnInit(): void {  
   
    this.weatherSrv.getCityweather(this.weatherSrv.userSettings).subscribe();
     
    
  }

}
