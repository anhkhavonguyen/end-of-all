import { Injectable } from '@angular/core';
import { HttpService } from '../../shared/services/http.service';

@Injectable()
export class CardService {

    constructor(private httpService: HttpService) {
    }
    
}
