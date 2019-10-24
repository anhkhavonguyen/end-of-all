export class CurrencyModel{
    public id = '';
    public name = '';
    public symbol = '';
    public slug = '';
    public isActive = '';
    public rank = '';
}

export class GetDataRequest {
    constructor(GetDataRequest?: any) {
        if (!GetDataRequest) { return; }
        this.pageIndex = GetDataRequest.pageNumber;
        this.pageSize = GetDataRequest.pageSize;
        this.searchText = GetDataRequest.searchText;
        this.dateFilter = GetDataRequest.dateFilter;
    }

    public pageIndex = 0;
    public pageSize = 0;
    public searchText = '';
    public dateFilter = '';
    public userId = '';
}

export class GetDataResponse {
    constructor(response?: any) {
        if (!response) { return; }
        this.results = response.Data;
        this.pageIndex = response.pageNumber;
        this.pageSize = response.pageSize;
        this.totalItem = response.totalItem;
    }
    public results!: Array<CurrencyModel>;
    public pageIndex = 0;
    public pageSize = 0;
    public totalItem = 0;
}