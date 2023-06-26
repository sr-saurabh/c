import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RidesService } from 'src/app/services/rides.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  userName:string="Jhon Wills";
  userImage:string="Jhon Wills";
  isDropdown:boolean=false;
  constructor(private router:Router, private ridesService:RidesService) { }

  ngOnInit(): void {
    var name=localStorage.getItem("name");
    if(name)
      this.userName=name;

  }
  goToHome(){
    this.router.navigate(["home"]);
  }
  nevigateToMyRides(){
    if(this.router.url!="/my-rides")
    {
      this.ridesService.getOfferedRides();
      this.ridesService.getBookedRides();
    }
    this.router.navigate(["my-rides"]);
  }

}
