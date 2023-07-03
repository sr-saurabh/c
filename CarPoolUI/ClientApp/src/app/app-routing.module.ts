import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { NavComponent } from './components/nav/nav.component';
import { HomeComponent } from './components/home/home.component';
import { BookRideComponent } from './components/book-ride/book-ride.component';
import { OfferRideComponent } from './components/offer-ride/offer-ride.component';
import { RideCardsComponent } from './components/ride-cards/ride-cards.component';
import { MyRidesComponent } from './components/my-rides/my-rides.component';
import { MyprofileComponent } from './components/myprofile/myprofile.component';
import { AuthGuardGuard } from './auth-guard.guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent},
  { path: 'home', component: HomeComponent, canActivate:[AuthGuardGuard] },
  { path: 'book-ride', component: BookRideComponent, canActivate:[AuthGuardGuard] },
  { path: 'offer-ride', component: OfferRideComponent, canActivate:[AuthGuardGuard] },
  { path: 'create-card', component: RideCardsComponent, canActivate:[AuthGuardGuard] },
  { path: 'my-rides', component: MyRidesComponent, canActivate:[AuthGuardGuard] },
  { path: 'myprofile', component: MyprofileComponent, canActivate:[AuthGuardGuard] },

  
  { path: '', redirectTo:'/login',pathMatch:'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }