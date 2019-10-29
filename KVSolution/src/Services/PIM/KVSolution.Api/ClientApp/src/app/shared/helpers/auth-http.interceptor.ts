import { Injectable, Injector } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { AuthService } from '../../auth/services/auth.service';

@Injectable()
export class AuthHttpInterceptor implements HttpInterceptor {

    constructor(
        private injector: Injector
        ) {
    }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const authService: AuthService = this.injector.get(AuthService);
        const accessToken = authService.getAccessToken();
        // TODO: need to change interceptor to base http service
        if (request.method === 'GET') {
            request = request.clone({
                setHeaders: {
                    Authorization: 'Bearer ' + accessToken,
                    Accept: 'application/json, text/plain, */*'
                }
            });
        } else if (request.method === 'POST' || request.method === 'PUT' || request.method === 'DELETE') {
            request = request.clone({
                setHeaders: {
                    Authorization: 'Bearer ' + accessToken,
                    Accept: 'application/json, text/plain, */*',
                    'Content-type': 'application/json; charset=utf-8'
                }
            });
        }
        return next.handle(request);
    }
}

