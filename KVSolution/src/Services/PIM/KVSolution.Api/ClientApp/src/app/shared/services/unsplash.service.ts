import { Injectable } from '@angular/core';
import Unsplash, { toJson } from "unsplash-js";

@Injectable()
export class UnsplashService {

    APP_ACCESS_KEY = '1c8a934eb5cbf48305a6a2b43892b46597a6299b1e3d44a29f0ce4b003aa0ed2';
    APP_SECRET = '660346335de2c2de13312092be2cb32f4c98afe017beb3763564ab96e4333934';
    LocationApiUri = 'https://api.unsplash.com/';
    unsplash;

    constructor() {
        this.unsplash = new Unsplash({
            applicationId: this.APP_ACCESS_KEY,
            secret: this.APP_SECRET,
            headers: {
                "X-Custom-Header": "foo"
            }
        });


        const authenticationUrl = this.unsplash.auth.getAuthenticationUrl([
            "public",
            "read_user",
            "write_user",
            "read_photos",
            "write_photos"
        ]);
    }

    public GetPhotoById(id: string, width?: number, height?: number, rectangle?: Array<number>) {
        return this.unsplash.photos.getPhoto(id, width, height, rectangle).then(toJson);
    }

    public GetPhotosByUsername(username: string, page?: number, perPage?: number, orderBy?: string, stats?: boolean) {
        return this.unsplash.users.photos(username, page, perPage, false).then(toJson);
    }

    public GetUserProfile(username: string) {
        return this.unsplash.users.profile(username).then(toJson);
    }
}
