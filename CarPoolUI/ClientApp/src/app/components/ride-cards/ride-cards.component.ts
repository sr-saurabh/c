import { Component, OnInit } from '@angular/core';
import { RideCard } from 'src/app/models/ride';
import { RidesService } from 'src/app/services/rides.service';

@Component({
  selector: 'app-ride-cards',
  templateUrl: './ride-cards.component.html',
  styleUrls: ['./ride-cards.component.scss']
})
export class RideCardsComponent implements OnInit {

  rideCards:RideCard[]=[];
  TempRideCards:RideCard[]=[];
  ride1:RideCard={} as RideCard;
  timeStamp?:string[];
  isShowThumbnail=false;
  constructor( private ridesService:RidesService) { }

  ngOnInit(): void {
    this.ridesService.getOfferedRides().subscribe(()=>{

    })
    
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
  }

}
