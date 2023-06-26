import { Component, ElementRef, OnInit, ViewChild,NgModule } from '@angular/core';
import { Router } from '@angular/router';
import { RideCard } from 'src/app/models/ride';
import { RidesService } from 'src/app/services/rides.service';
// import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-book-ride',
  templateUrl: './book-ride.component.html',
  styleUrls: ['./book-ride.component.scss']
})
export class BookRideComponent implements OnInit {

  rideCards:RideCard[]=[];
  TempRideCards:RideCard[]=[];
  
  ride1:RideCard={} as RideCard;
  ride2:RideCard={} as RideCard;
  timeStamp:string[]=[];
  isChecked:boolean=true;
  oldClass!:string;
  newClass!:string;

  rideTime:string="";
  ridefrom:string="";
  rideTo:string="";
  rideDate!:Date;
  crntDate=new Date();

  // private toaster: ToastrService
  constructor(private rideService:RidesService, private router:Router) { }

  ngOnInit(): void {
    this.timeStamp=this.rideService.timeStamp();
    this.ride1={
      name:"saurabh kumar",
      image: "assets/saurabh.jpg",
      from:"Patna",
      to:"Bhilai",
      date:new Date(),
      time:"6pm - 9pm",
      seats:2,
      price:100
    }
    this.ride2=this.ride1;
    this.TempRideCards.push(this.ride1);
    this.TempRideCards.push(this.ride2);
    this.TempRideCards.push(this.ride2);

  }
  toogleRide(){
    this.router.navigate(['offer-ride']);
  }
  addTime(time:string){
    this.rideTime=time;

  }
  getMatches(formValue:any){
    let source=this.ridefrom.toLowerCase();
    let destination=this.rideTo.toLowerCase();
    if(source===destination)
    {
      // this.toaster.warning("Source and destination should be different.","warning")
      alert("Source and destination should be different.");

      return;
    }
    console.log(this.rideTime);
    console.log(this.ridefrom);
    console.log(this.rideTo);
    console.log(this.rideDate);
    this.rideService.getMatchedRides(source,destination, this.timeStamp.indexOf(this.rideTime),this.rideDate);
  }
  

}
