import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';

import { AuthService } from './auth.service';


@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private auth: AuthService) { }

    /**
    * WHEN
    * the routing to the page happens
    *
    * FOR WHAT
    * to get the authenrication status
    *
    * WHY
    * check if the user is authenticated
    *
    * HOW
    * by getting the variable used in the authservice.ts
    */
    canActivate() {
        if (this.auth.authenticated) {
            return true;
        }
        return false;
    }
}