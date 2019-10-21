
import { Injectable } from '@angular/core';
import { HttpService } from '../../shared/services/http.service';

@Injectable()
export class ContentService {


    mediumUrl = 'https://medium.com/@khavo1412/latest?format=json'

    constructor(private httpService: HttpService) {
    }

    public get() {
        return this.httpService.get(this.mediumUrl);
    }
}
