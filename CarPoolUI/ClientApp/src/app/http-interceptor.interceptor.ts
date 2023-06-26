import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
@Injectable()
export class HttpInterceptorInterceptor implements HttpInterceptor {

  constructor() {
    console.log(this.intercept);
    
  }
  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<any>> {
    var token!:string;
    console.log("hii");
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

    return next.handle(httpRequest);

    // .pipe(
    //   catchError((error) => {
    //     if (error.status === 401) {
    //       this.router.navigate(['auth']);
    //     }
    //     return throwError(error);
    //   })
    // )


  }
}