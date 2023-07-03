import { Injectable } from '@angular/core';
import { AuthResponse } from '../models/auth-response';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/response';
import { UpdateUser } from '../models/changeUser';
import { UpdatePassword } from '../models/updatePassword';

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
  updateUser(user:UpdateUser):Observable<ApiResponse>
  {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };
    return this.http.post<ApiResponse>(`https://localhost:7221/api/Auth/update-user-details`,user,httpOptions);
  } 
  updatePassword(userPassword:UpdatePassword):Observable<ApiResponse>
  {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };
    return this.http.post<ApiResponse>(`https://localhost:7221/api/Auth/change-password`,userPassword,httpOptions);
  } 

}
