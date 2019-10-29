import { Injectable } from '@angular/core';

@Injectable()
export class StorageService {

    public get(key: string) {
        return localStorage.getItem(key);
    }

    public set(key: string, value: string) {
        localStorage.setItem(key, value);
    }

    public clear(key: string) {
        localStorage.removeItem(key);
    }
}

