import { Component, ElementRef, OnInit, ViewChild,NgModule } from '@angular/core';
import { Router } from '@angular/router';
import { ApiResponse } from 'src/app/models/response';
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
  timeStamp:string[]=[];
  isChecked:boolean=true;
  isSubmitted:boolean=false;

  rideTime:string="";
  ridefrom:string="";
  rideTo:string="";
  rideDate!:Date;
  crntDate=new Date();
  showSeats:boolean=false;
  seats:number[]=[1,2,3,4];
  selectedRide:RideCard={}as RideCard;
  seatCount:number=0;

  // private toaster: ToastrService
  constructor(private rideService:RidesService, private router:Router) { }

  ngOnInit(): void {
    this.timeStamp=this.rideService.timeStamp();
  }

  toogleRide(){
    this.router.navigate(['offer-ride']);
  }

  addTime(time:string){
    this.rideTime=time;    
  }

  getMatches(){
    let source=this.ridefrom;
    let destination=this.rideTo;
    if(source.toLowerCase()===destination.toLowerCase())
    {
      alert("Source and destination should be different.");
      return;
    }

    var rideData=this.rideService.getMatchedRides(source,destination, this.timeStamp.indexOf(this.rideTime)+1,this.rideDate);
    rideData.subscribe((rides)=>{  
      console.log(rides);
      if(rides!=null) 
        this.rideCards=rides;
      else
        this.rideCards=[];
      
      this.isSubmitted=true;
    })
  }

  selectRide(rideCard:RideCard|null,isShowSeatForm:boolean){
    this.showSeats=isShowSeatForm;
    if(rideCard!=null )
      this.selectedRide={...rideCard};
  }
  addSeat(seat:number)
  {
    this.seatCount=seat;
  }
  bookRide(){
    this.selectedRide.seats=this.seatCount;
    console.log(this.selectedRide);     
    this.rideService.bookRide(this.selectedRide).subscribe((response:ApiResponse)=>{
      this.showSeats=false;
      console.log(response);
      this.getMatches();
      alert(response.responseMessage);
    })  

  }

}
