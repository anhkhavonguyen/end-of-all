import { Injectable } from '@angular/core';
import { HttpService } from '../../shared/services/http.service';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';
import { GetDataRequest, GetDataResponse } from './models/cryptocurrency.model';

const api = 'Cryptocurrency';

@Injectable()
export class CryptocurrencyService {

    constructor(private httpService: HttpService) {
    }

    public get(request: GetDataRequest): Observable<GetDataResponse> {
        const apiUrl = `${environment.authorityUri}/${api}`;
        return this.httpService.get(apiUrl, request);
    }
}
