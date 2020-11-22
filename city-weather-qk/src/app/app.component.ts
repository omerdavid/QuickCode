import { Component } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';
import { WeatherService } from './weather/weather.service';
import { tap,filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'Weather Atm';
  isSettingPage:boolean;

  constructor(public weatherSrv:WeatherService,private route:Router) {

     //Option 1
      this.weatherSrv.title$.subscribe(t=>{
        this.isSettingPage=t!=='Settings';
        this.title=t;
      });

      //Option 2 listen to navigation events
  this.route.events.pipe(filter(r=> r instanceof NavigationStart )).subscribe((n:NavigationStart)=>{
  
      //  this.isSettingPage=n.url!=='/settings';
  });

   //Option 3 add a second observable in weather service that is fired on route change 

   }
}
