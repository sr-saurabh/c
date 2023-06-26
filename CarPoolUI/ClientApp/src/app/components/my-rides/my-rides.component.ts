import { Component, OnInit } from '@angular/core';
import { RideCard } from 'src/app/models/ride';

@Component({
  selector: 'app-my-rides',
  templateUrl: './my-rides.component.html',
  styleUrls: ['./my-rides.component.scss']
})
export class MyRidesComponent implements OnInit {

  rideCards:RideCard[]=[];
  TempRideCards:RideCard[]=[];
  ride1:RideCard={} as RideCard;
  ride2:RideCard={} as RideCard;
  constructor() { }

  ngOnInit(): void {
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

}
