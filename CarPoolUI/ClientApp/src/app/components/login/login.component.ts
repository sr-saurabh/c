import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { AuthResponse } from 'src/app/models/auth-response';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  formEmail:string="";
  formPassword:string="";
  confirmPassword:string="";
  formTitle:string="Sign Up";
  formReference:string="Log In";
  isSignUp:boolean=true;
  viewPassword:boolean=false;
  errorMessage:string="";
  isError:boolean=false;

  @ViewChild('btn') submitBtn!: ElementRef;
  @ViewChild('login') loginDiv!: ElementRef;
  constructor( private authService:AuthService) { }

  ngOnInit(): void {
    
  }
  
  showPassword(){
    this.viewPassword=!this.viewPassword;
  }

  changeFormType()
  {
    if( this.formTitle=="Sign Up")
    {
      this.formTitle="Log In";
      this.formReference="Sign Up";
      this.submitBtn.nativeElement.classList.add("background-yellow");
      this.loginDiv.nativeElement.classList.add("background-purple");
    }
    else{
      this.formTitle="Sign Up";
      this.formReference="Log In";
      this.submitBtn.nativeElement.classList.remove("background-yellow");
      this.loginDiv.nativeElement.classList.remove("background-purple");
    }
    this.isSignUp=!this.isSignUp;

  }

  
  submit(){   
    if(this.formTitle=="Sign Up") 
    {
      if(this.formPassword!=this.confirmPassword)
      {
        this.errorMessage="Password does not match.";
        this.isError=true;
      }
      else
      {
        this.errorMessage="";
        this.isError=false;
        this.authService.signup(this.formEmail,this.formPassword).subscribe((response)=>{
          console.log(response);
          this.saveResponse(response);
        },
        (error)=>{
          console.log(error.error);
          this.errorMessage=error.error;
          this.isError=true;
        }
        );
      }
    }
    else
    {
      this.authService.login(this.formEmail,this.formPassword).subscribe((response)=>{
        this.saveResponse(response);
        console.log(response);
      },
      (error)=>{
        console.log(error.error);
        this.errorMessage=error.error;
        this.isError=true;
      }
      
      );
    }
  }


  saveResponse(response:AuthResponse)
  {
    localStorage.setItem("response",JSON.stringify(response))
  }
}
