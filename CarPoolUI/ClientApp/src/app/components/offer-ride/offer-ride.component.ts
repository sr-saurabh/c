import { Component, OnInit } from '@angular/core';
import {  Router } from '@angular/router';
import { OfferRide } from 'src/app/models/offre-ride';
import { RidesService } from 'src/app/services/rides.service';
import { Guid } from '../../../../node_modules/guid-typescript';
import { ApiResponse } from 'src/app/models/response';


@Component({
  selector: 'app-offer-ride',
  templateUrl: './offer-ride.component.html',
  styleUrls: ['./offer-ride.component.scss']
})
export class OfferRideComponent implements OnInit {

  timeStamp:string[]=[];
  isValidationSuccess!:boolean;
  offerRideData:OfferRide={} as OfferRide;
  stops:number[]=[1,2,3];
  seats:number[]=[1,2,3];
  stop:string[]=["","",""];
  isTimeValid!:boolean;
  crntDate=new Date();
  offerData:OfferRide["offeredRides"]={}as OfferRide["offeredRides"]
  ;
  constructor(private rideService:RidesService, private router:Router) { }

  ngOnInit(): void {
    this.timeStamp=this.rideService.timeStamp();   
    this.offerData.price=180;
  }
  toogleRide(){
    this.router.navigate(['book-ride']);
  }
  
  saveTime(time:string)
  {
    this.offerData.time=this.timeStamp.indexOf(time)+1;
  }

  validateDetail(isFormValid:boolean|null)
  {  
    if(!isFormValid || this.isTimeValid==false)
    {
      this.isValidationSuccess=false;
      return;
    }
    else
    {
      if(this.offerData.source==undefined || this.offerData.destination==undefined|| this.offerData.source.toLowerCase()===this.offerData.destination.toLowerCase())
      {
        alert("Source and destination should be different.");
        this.isValidationSuccess=false;
      return;
    }
    this.isValidationSuccess=true;
    }
    if(this.offerData.time==undefined)
      this.isTimeValid=false;
    else 
      this.isTimeValid=true;
  }
  
  removeStop(idx:number){
    this.stop.pop();
    this.stops.pop();
  }

  addStops(){
    this.stop.push("");
    this.stops.push(this.stops.length);
  }

  addLocation(idx:number,stop:string){
    this.stop[idx]=stop;
  }

  addSeats(seats:number){
    this.offerData.totalSeats=seats;
    this.offerData.availableSeats=seats;
  }

  submitForm(next:any){

    var stoppages = this.stop.filter(stop => stop.length >0);
    stoppages.forEach(function(stop, index, stoppages) {
      stoppages[index] = stop.toLowerCase();
      });
    if(stoppages.length>0)
    {
      var isDuplicate=this.checkConflits(stoppages, this.offerData.source, this.offerData.destination);
      if(isDuplicate)
      {
        alert("Every Location should be different");
        return;
      }
      this.offerRideData.locations=stoppages;
    }
    this.offerData.offeredRideId=Guid.create().toString();

    var offerData={...this.offerRideData}
    offerData.offeredRides=this.offerData;
    offerData.offeredRides.source=this.offerData.source.toLocaleLowerCase();
    offerData.offeredRides.destination=this.offerData.destination.toLocaleLowerCase();

    // console.log(offerData);
    this.rideService.offerRide(offerData).subscribe((x)=>{
      console.log(x.responseMessage);
      alert(x.responseMessage);
    })
  }

  private checkConflits(stoppages:string[], source:string, destination:string){
    var result=[...stoppages]
    result.push(source.toLocaleLowerCase());
    result.push(destination.toLocaleLowerCase());
    // let count:any={};
    // var isDuplicate=false;
    // result.forEach((stop)=>{
    //   if(count[stop]===undefined)
    //   {
    //     count[stop]=1;
    //   }
    //   else{
    //     isDuplicate=true;
    //     break;
    //   }

    // })
    return new Set(result).size !== result.length;



  }
}
