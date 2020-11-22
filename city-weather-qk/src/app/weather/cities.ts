
export class City{
  name:string;
  cityId:number;
  /**
   *
   */
  constructor(_name:string,_cityId:number) {
       this.name=_name;
       this.cityId=_cityId;
      
  }
}
export const Cities=[new City('Jerusalem',281184),new City('Tel-Aviv',293397),new City('Rishon-Leziyyon',293703)];