import { Injectable } from '@angular/core';
import { RideCard } from '../models/ride';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class RidesService {

  constructor(private http: HttpClient) { }
  timeStamp(){
    return ["5am - 9am", "9am - 12pm", "12pm - 3pm", "3pm - 6pm", "6pm - 9pm"]
  }

  getMatchedRides(source:string, destination:string, time:number, date:Date ):Observable<RideCard[]>
  {
    var x= this.http.get<RideCard[]>(`https://localhost:7221/api/BookRide/get-matched-rides?source=${source}&destination=${destination}&date=${date}&time=${time}`);
    console.log(x);
    return x;
  }

  getOfferedRides():Observable<RideCard>
  {
    console.log("kk1");
    return this.http.get<RideCard>(`https://localhost:7221/api/OfferRide/get-offered-rides`);
    
  }
  getBookedRides(){
    console.log("kk2");
    
    return this.http.get<RideCard>(`https://localhost:7221/api/BookRide/get-booked-rides`);
  }




}
