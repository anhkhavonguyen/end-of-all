import { Injectable } from '@angular/core';
import { HttpService } from '../../shared/services/http.service';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import {
    BlogModel,
    BlogRequest,
    GetBlogsRequest,
    GetBlogsResponse
} from './models/blog.model';

const blogApi = 'blogs';

@Injectable()
export class CardService {

    constructor(private httpService: HttpService) {
    }

    public get(request: GetBlogsRequest): Observable<GetBlogsResponse> {
        const apiUrl = `${environment.authorityUri}/${blogApi}`;
        return this.httpService.get(apiUrl, request);
    }

    public getBlogsNoPaging(): Observable<any> {
        const apiUrl = `${environment.authorityUri}/${blogApi}/without-paging`;
        return this.httpService.get(apiUrl);
    }

    public getCustomerById(id: string): Observable<BlogModel> {
        const apiUrl = `${environment.authorityUri}/${blogApi}/${id}`;
        return this.httpService.get(apiUrl);
    }

    public add(request: BlogRequest): Observable<boolean> {
        const apiUrl = `${environment.authorityUri}/${blogApi}/create`;
        return this.httpService.post(apiUrl, request);
    }

    public edit(request: BlogRequest): Observable<boolean> {
        const apiUrl = `${environment.authorityUri}/${blogApi}`;
        return this.httpService.put(apiUrl, request);
    }

    public delete(request: any): Observable<boolean> {
        const apiUrl = `${environment.authorityUri}/${blogApi}`;
        return this.httpService.delete(apiUrl, request);
    }
}
