import { Component, OnInit } from '@angular/core';
import { UpdateUser } from 'src/app/models/changeUser';
import { ApiResponse } from 'src/app/models/response';
import { UpdatePassword } from 'src/app/models/updatePassword';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-myprofile',
  templateUrl: './myprofile.component.html',
  styleUrls: ['./myprofile.component.scss']
})
export class MyprofileComponent implements OnInit {


  name:string="";
  image:string="";
  email:string="";

  newImage:string="";
  newName:string="";

  userPassword:UpdatePassword={} as UpdatePassword;
  confirmPassword:string="";

  isError:boolean=false;
  viewOldPassword:boolean=false;
  viewNewPassword:boolean=false;
  isUpdatePassword:boolean=false;
  isUpdateUserDetail:boolean=false;
  isPasswordMatching:boolean=true;
  isPasswordSame:boolean=false;






  constructor(private authService:AuthService) { }

  ngOnInit(): void {
    var data=localStorage.getItem("response");
    if(data!=null)
    {
      var parsedData=JSON.parse(data);
      this.image=parsedData.image;
      this.name=parsedData.name;
      this.email=parsedData.email;
    }
  }

  showPassword(type:string){
    if(type=='old')
      this.viewOldPassword=!this.viewOldPassword;
    else
      this.viewNewPassword=!this.viewNewPassword;
  }
  openUserDetailForm(){
    this.isUpdateUserDetail=!this.isUpdateUserDetail;
    this.isError=false;
  }
  openPasswordForm(){
    this.isUpdatePassword=!this.isUpdatePassword;
  }

  saveImage(event: any) {
    if (event.target.files.length>0) {            
      var reader = new FileReader();
      reader.readAsDataURL(event.target.files[0]);
      reader.addEventListener('load', (e: any) => {
        this.newImage = e.target.result; 
      });
    }
    else
      this.newImage =this.image;
  }

  updateUser(isNameInvalid:any){

    if(this.newImage=="")
      this.newImage=this.image;
      
    if(this.newName==""||isNameInvalid)
    {
      this.isError=true;
      return;
    }
    else
      this.isError=false;
    
    var user:UpdateUser={newName:this.newName,newImage:this.newImage};
    this.authService.updateUser(user).subscribe((response:ApiResponse)=>{
      alert(response.responseMessage);
      if(response.responseMessage=="Updated Successfully")
      {
        var data=localStorage.getItem("response");
        if(data!=null)
        {
          var x=JSON.parse(data);
          x["name"]=this.newName;
          x["image"]=this.newImage;
          localStorage.setItem("response",JSON.stringify(x));
        }
      }
    })
    this.openUserDetailForm();

  }

  updatePassword(isConfPassInvalid:boolean|null, isNewPassInvalid:boolean|null, isOldPassInvalid:boolean|null ){
    if(isConfPassInvalid|| isNewPassInvalid || isOldPassInvalid)
    {
      this.isError=true;
      return;
    }
    else
      this.isError=false;
    
    if(this.userPassword.newPassword===this.userPassword.oldPassword)
    {
      this.isPasswordSame=true;
      return;
    }
    else
      this.isPasswordSame=false;
    
    if(this.confirmPassword!=this.userPassword.newPassword)
    {
      this.isPasswordMatching=false;
      return;
    }
    else
      this.isPasswordMatching=true;


    this.authService.updatePassword(this.userPassword).subscribe((response:ApiResponse)=>{
      console.log(response);
      alert(response.responseMessage)

    })
    this.openPasswordForm();
    // console.log(this.userPassword);
    // console.log(this.confirmPassword);
    
  }
}
