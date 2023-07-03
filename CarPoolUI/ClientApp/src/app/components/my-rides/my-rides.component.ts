import { Component, OnInit } from '@angular/core';
import { RideCard } from 'src/app/models/ride';
import { RidesService } from 'src/app/services/rides.service';

@Component({
  selector: 'app-my-rides',
  templateUrl: './my-rides.component.html',
  styleUrls: ['./my-rides.component.scss']
})
export class MyRidesComponent implements OnInit {

  rideCards:RideCard[]=[];
  bookedRides:RideCard[]=[];
  offeredRides:RideCard[]=[];
  TempRideCards:RideCard[]=[];
  ride1:RideCard={} as RideCard;
  constructor(private ridesService:RidesService) { }

  ngOnInit(): void {
    this.ride1={
      name:"saurabh kumar",
      image: "assets/saurabh.jpg",
      source:"Patna",
      destination:"Bhilai",
      date:new Date(),
      time:"6pm - 9pm",
      seats:2,
      price:100
    }
    this.TempRideCards.push(this.ride1);
    this.TempRideCards.push(this.ride1);
    this.TempRideCards.push(this.ride1);
    this.ridesService.getBookedRides().subscribe((ride:any)=>
    {
      this.bookedRides=ride;
    })
    this.ridesService.getOfferedRides().subscribe((ride:any)=>
    {
      this.offeredRides=ride;
    })
  }

}
