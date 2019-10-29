import { Component } from '@angular/core';
import { CryptocurrencyService } from './cryptocurrency.service';
import { GetDataRequest, CurrencyItem } from './models/cryptocurrency.model';
import { map } from 'rxjs/operators';

@Component({
    templateUrl: 'cryptocurrency.component.html',
    styleUrls: ['./cryptocurrency.component.scss']
})
export class CryptocurrenciesComponent {

    constructor(private cryptocurrencyService: CryptocurrencyService) {
        this.get();
    }

    data: CurrencyItem[];

    public get() {
        let request = new GetDataRequest();
        request.searchText = 'BTC,USDT,BNB';
        this.cryptocurrencyService.get(request).subscribe(data => {
            console.log(data);
            this.data = data.data.sort(v=> Number(v.rank));
        })
    }
}
