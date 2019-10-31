export class BlogModel {
    public link = '';
    public text = '';
    public title = '';
    public categoryId = '';
}

export class GetBlogsRequest {
    constructor(GetBlogsRequest?: any) {
        if (!GetBlogsRequest) { return; }
        this.pageIndex = GetBlogsRequest.pageNumber;
        this.pageSize = GetBlogsRequest.pageSize;
        this.searchText = GetBlogsRequest.searchText;
        this.dateFilter = GetBlogsRequest.dateFilter;
    }

    public pageIndex = 0;
    public pageSize = 0;
    public searchText = '';
    public dateFilter = '';
    public userId = '';
}

export class GetBlogsResponse {
    constructor(response?: any) {
        if (!response) { return; }
        this.results = response.blogListResponse;
        this.pageIndex = response.pageNumber;
        this.pageSize = response.pageSize;
        this.totalItem = response.totalItem;
    }
    public results!: Array<BlogModel>;
    public pageIndex = 0;
    public pageSize = 0;
    public totalItem = 0;
}

export class BlogRequest {
    constructor(request?: any) {
        if (!request) { return; }
        this.blogModel = request.blogModel;
    }
    public blogModel: BlogModel;
}