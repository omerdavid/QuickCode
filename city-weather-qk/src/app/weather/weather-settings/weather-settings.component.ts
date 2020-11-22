import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../weather.service';
import { Location } from '@angular/common';

import { FormBuilder, FormGroup } from '@angular/forms';
import { UserSettings } from '../models/user-settings';
import { Router } from '@angular/router';

@Component({
  selector: 'app-weather-settings',
  templateUrl: './weather-settings.component.html',
  styleUrls: ['./weather-settings.component.css']
})
export class WeatherSettingsComponent implements OnInit {
 
  
 
  weatherForm:FormGroup;

  constructor(public weatherSrv:WeatherService, private _location: Location,private fb:FormBuilder,private router:Router) {
  
    this.weatherSrv.title="Settings";
   
    

    this.weatherForm=fb.group({
    city:[this.weatherSrv.cities[0]],
    unit:[this.weatherSrv.neeededUnits[0]]

    });

   }

  ngOnInit(): void {

  }
 back(){
   this._location.back();
 }
 
 save(){ 
 
   const userSettings=new UserSettings();
  
   userSettings.city=this.weatherForm.controls.city.value;
   userSettings.units=this.weatherForm.controls.unit.value;

   this.weatherSrv.getCityweather(userSettings).subscribe(r=>{
    this.router.navigate(['/']);
   });

 }
}
