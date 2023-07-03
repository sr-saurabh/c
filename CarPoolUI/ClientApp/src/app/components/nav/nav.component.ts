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
  userImage:string="../../../assets/imageNotAdded.jpg";
  isDropdown:boolean=false;
  constructor(private router:Router, private ridesService:RidesService) { }

  ngOnInit(): void {

    var data=localStorage.getItem("response");
    if(data!=null)
    {

      this.userImage=JSON.parse(data)["image"];
      this.userName=JSON.parse(data)["name"];
    }
  }
  goToHome(){
    this.router.navigate(["home"]);
  }
  nevigateToMyRides(){
    if(this.router.url!="/my-rides")
      this.router.navigate(["my-rides"]);
  }

  logout(){
    localStorage.clear();
    this.router.navigate(["login"]);
  }

  nevigateToMyProfile(){
    if(this.router.url!="/myprofile")
    {
      this.router.navigate(["myprofile"]);
    }
  }
}
