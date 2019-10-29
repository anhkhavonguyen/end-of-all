import { Injectable } from '@angular/core';
import {
    Router,
    CanActivate,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
} from '@angular/router';
import { AuthService } from '../services/auth.service';
import { StorageService } from '../services/storage.service';
import { CommonConstant } from '../../constants/common.constant';

@Injectable()
export class AuthGuardService implements CanActivate {
    constructor(
        private router: Router,
        private authService: AuthService,
        private storageService: StorageService
    ) {
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const hasValidAccessToken = this.authService.hasValidAccessToken();
        if (hasValidAccessToken) {
            return true;
        }
        const previousUrl = state.url;
        this.storageService.set(CommonConstant.localStorageKey.previousLoginUrl, previousUrl);
        this.router.navigate([CommonConstant.route.login]);
        return false;
    }
}
