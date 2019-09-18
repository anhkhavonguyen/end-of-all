import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/shared/services/http.service';

const imageApi = 'https://unsplash.com/photos/ILJ-tlaXxfQ';

@Injectable()
export class MyImageService {


    constructor(private httpService: HttpService) {
    }

    public GetImage() {
        const apiUrl = `${imageApi}`;
        return this.httpService.get(apiUrl);
    }
}
