import { Component } from '@angular/core';
import { CryptocurrencyService } from './cryptocurrency.service';
import { GetDataRequest } from './models/cryptocurrency.model';

@Component({
    templateUrl: 'cryptocurrency.component.html',
    styleUrls: ['./cryptocurrency.component.scss']
})
export class CryptocurrenciesComponent {

    constructor(private cryptocurrencyService: CryptocurrencyService) {
        this.get();
    }

    public get() {
        let request = new GetDataRequest();
        request.searchText = 'BTC,USDT,BNB';
        this.cryptocurrencyService.get(request).subscribe(data => {
            console.log(data);
        });
    }
}
