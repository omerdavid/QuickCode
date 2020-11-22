import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WeatherMasterComponent } from './weather/weather-master/weather-master.component';
import { WeatherSettingsComponent } from './weather/weather-settings/weather-settings.component';


const routes: Routes = [
  {path:'',component:WeatherMasterComponent},
  {path:'settings',component:WeatherSettingsComponent}
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
