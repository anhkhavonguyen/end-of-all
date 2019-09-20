import { Injectable } from '@angular/core';
import { HttpService } from '../../shared/services/http.service';

@Injectable()
export class MyImageService {

    constructor(private httpService: HttpService) {
    }
    
}
