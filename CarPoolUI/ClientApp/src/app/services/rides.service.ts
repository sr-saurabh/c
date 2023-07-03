import { Injectable } from '@angular/core';
import { RideCard } from '../models/ride';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OfferRide } from '../models/offre-ride';
import { ApiResponse } from '../models/response';


@Injectable({
  providedIn: 'root'
})
export class RidesService {

  constructor(private http: HttpClient) { }
  timeStamp(){
    return ["5am - 9am", "9am - 12pm", "12pm - 3pm", "3pm - 6pm", "6pm - 9pm"]
  }

  offerRide(offferRideData:OfferRide){
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };
    return this.http.post<ApiResponse>(
      'https://localhost:7221/api/OfferRide',
      offferRideData,
      httpOptions
    );
  }

  getMatchedRides(source:string, destination:string, time:number, date:Date ):Observable<RideCard[]>
  {
   return this.http.get<RideCard[]>(`https://localhost:7221/api/BookRide/get-matched-rides?source=${source}&destination=${destination}&date=${date}&time=${time}`);
  }
  
  bookRide(ride:RideCard):Observable<ApiResponse>
  {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };
    return this.http.post<ApiResponse>("https://localhost:7221/api/BookRide/book-ride",ride, httpOptions);
  }

  
  getOfferedRides():Observable<RideCard>
  {
    return this.http.get<RideCard>(`https://localhost:7221/api/OfferRide/get-offered-rides`);
    
  }
  getBookedRides(){    
    return this.http.get<RideCard>(`https://localhost:7221/api/BookRide/get-booked-rides`);
  }




}
