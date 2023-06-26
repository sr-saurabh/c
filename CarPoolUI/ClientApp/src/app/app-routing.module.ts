import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { NavComponent } from './components/nav/nav.component';
import { HomeComponent } from './components/home/home.component';
import { BookRideComponent } from './components/book-ride/book-ride.component';
import { OfferRideComponent } from './components/offer-ride/offer-ride.component';
import { RideCardsComponent } from './components/ride-cards/ride-cards.component';
import { MyRidesComponent } from './components/my-rides/my-rides.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignUpComponent},
  { path: 'nav', component: NavComponent},
  { path: 'home', component: HomeComponent},
  { path: 'book-ride', component: BookRideComponent},
  { path: 'offer-ride', component: OfferRideComponent},
  { path: 'create-card', component: RideCardsComponent},
  { path: 'my-rides', component: MyRidesComponent},

  
  { path: '', redirectTo:'/login',pathMatch:'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }