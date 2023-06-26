import { Component, OnInit } from '@angular/core';
import {  Router } from '@angular/router';
import { RidesService } from 'src/app/services/rides.service';

@Component({
  selector: 'app-offer-ride',
  templateUrl: './offer-ride.component.html',
  styleUrls: ['./offer-ride.component.scss']
})
export class OfferRideComponent implements OnInit {

  timeStamp?:string[];
  isValidationSuccess:boolean=false;
  stops:number[]=[1,2,3];
  rideValue:number=180;
  constructor(private rideService:RidesService, private router:Router) { }

  ngOnInit(): void {
    this.timeStamp=this.rideService.timeStamp();
  }
  toogleRide(){
    this.router.navigate(['book-ride']);
  }

  validateDetail(x:any)
  {
    console.log(x);
    
      this.isValidationSuccess=true;
      return true;
  }
  removeStop(idx:number){
    this.stops.pop();
    
  }
  addStops(){
    this.stops.push(this.stops.length);
  }
  saveTime(time:string)
  {
    console.log(time);
  }
}
