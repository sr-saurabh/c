import { Injectable } from '@angular/core';
import { AuthResponse } from '../models/auth-response';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }
  login(email:string, password:string):Observable<AuthResponse>
  {

    return this.http.get<AuthResponse>(`https://localhost:7221/api/Auth/login?email=${email}&&password=${password}`);
  }
  signup(email:string, password:string)
  {

    return this.http.get<AuthResponse>(`https://localhost:7221/api/Auth/signUp?email=${email}&&password=${password}`);
  }
}
