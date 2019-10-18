import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class HttpService {

    constructor(private http: HttpClient) {
    }

    public post<T>(url: string, data?: T, option?: Object): Observable<any> {
        return this.http
            .post<T>(url, data, option);
    }

    public put<T>(url: string, data?: T): Observable<any> {
        return this.http
            .put<T>(url, data);
    }

    public delete(url: string, data?: any) {
        return this.http
            .delete<boolean>(url, { params: data });
    }

    public get<T>(url: string, option?: any): Observable<T> {
        if (option) {
            return this.http
                .get<T>(url, { params: option });
        } else {
            return this.http
                .get<T>(url);
        }
    }
}
