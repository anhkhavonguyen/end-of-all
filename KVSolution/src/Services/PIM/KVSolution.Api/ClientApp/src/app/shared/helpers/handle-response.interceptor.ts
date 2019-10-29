import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http/';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { CommonConstant } from '../../constants/common.constant';
import { AuthService } from '../../auth/services/auth.service';
import { StorageService } from '../../auth/services/storage.service';

@Injectable()
export class HandleResponseInterceptor implements HttpInterceptor {
  constructor(
    private router: Router,
    private authService: AuthService,
    private storage: StorageService,
  ) { }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      map((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
          console.log('event', event);
        }
        return event;
      }),
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401) {
          this.authService.clearAccessToken();
          this.router.navigate([CommonConstant.route.login]);
        } else if (error.status === 404) {

        } else if (error.status === 500) {

        } else {

        }
        return throwError(error);
      }));
  }
}
