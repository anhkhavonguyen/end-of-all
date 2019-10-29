import { Injectable } from '@angular/core';
import { StorageService } from './storage.service';
import { HttpClient, HttpHeaders, HttpBackend } from '@angular/common/http';
import { Observable, of, Subject } from 'rxjs';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { CommonConstant } from '../../constants/common.constant';

const issuer = environment.authorityUri;
const grant_type = 'password';

@Injectable()
export class AuthService {
    protected key = 'access_token';
    public isFailLoginSubcription = new Subject<any>();
    private httpSkipInterceptor: HttpClient;

    constructor(
        private storage: StorageService,
        private http: HttpClient,
        private router: Router,
        httpBackend: HttpBackend
    ) {
        this.httpSkipInterceptor = new HttpClient(httpBackend);
    }

    public getAccessToken() {
        return this.storage.get(this.key);
    }

    public setAccessToken(token: string) {
        this.storage.set(this.key, token);
    }

    public clearAccessToken() {
        this.storage.clear(this.key);
    }

    public hasValidAccessToken() {
        const accessToken = this.getAccessToken();
        return accessToken && accessToken !== 'undefined' ? true : false;
    }

    public getToken(user: {username: string, password: string}): Observable<any> {
        const body = new URLSearchParams();
        const options =  new HttpHeaders({ 'Content-Type': 'application/json'});
        const url = issuer + '/Authentication/request';
        body.set('username', user.username);
        body.set('password', user.password);

        return this.httpSkipInterceptor.post(url, JSON.stringify(user), {headers: options, responseType: 'text'});
    }

    public login(user: {username: string, password: string}) {
        if (user) {
            this.getToken(user).subscribe((data: any) => {
                if (data) {
                    this.storage.set(this.key, data);
                    const previousUrl = this.storage.get(CommonConstant.localStorageKey.previousLoginUrl);
                    this.router.navigateByUrl(previousUrl);

                } else {
                    this.isFailLoginSubcription.next('Login fail');
                }
            }, err => {
                const errorMessage = 'Login fail';
                this.isFailLoginSubcription.next(errorMessage);
            });
        } else {
            this.isFailLoginSubcription.next('User is invalid');
        }
    }
}

