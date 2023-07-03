import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { Router } from '@angular/router';
@Injectable()
export class HttpInterceptorInterceptor implements HttpInterceptor {

  constructor(private router:Router) {  }
  
  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    var token!:string;
    var data=localStorage.getItem("response");
    if(data!=null)
    {
      token=JSON.parse(data)["token"];
    }
    if (!token) {
      return next.handle(request);
    }
    const httpRequest = request.clone({
      headers: request.headers.set('Authorization', `Bearer ${token}`),
    });

    return next.handle(httpRequest).pipe(
      catchError((error) => {
        if (error.status === 401) {
          alert("please login first!")
          this.router.navigate(['login']);
        }
        return throwError(error);
      })
    )


  }
}