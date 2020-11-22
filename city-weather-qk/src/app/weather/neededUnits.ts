export class Unit{
    name:string;
    id:string;
    /**
     *
     */
    constructor(_name:string,_id:string) {
        
        this.name=_name;
        this.id=_id;
    }
}
export const neeededUnits=[new Unit('Celsius','metric'),new Unit('Fahrenheit','Imperial')];