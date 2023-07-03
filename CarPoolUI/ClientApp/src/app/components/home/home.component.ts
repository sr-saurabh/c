import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  name:string="Jhon";
  constructor(private router :Router) { }

  ngOnInit(): void {
    var data=localStorage.getItem("response");
    if(data!=null)
      this.name=JSON.parse(data)["name"];
  }
  openBookRide(){
    this.router.navigate(['book-ride']);
  }
  openOfferRide(){
    this.router.navigate(['offer-ride']);

  }
}
