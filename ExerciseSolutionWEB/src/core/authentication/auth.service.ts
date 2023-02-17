import { Injectable } from "@angular/core";
import { NgxConfigureService } from "ngx-configure";
import { HttpService } from "../httpservice";


@Injectable({
    providedIn: 'root'
})

export class AuthService {
    config: any;

    constructor(public httpService: HttpService, public configService: NgxConfigureService) {
        this.config = configService.config;
    }

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
    get authenticated(): boolean {
        if (this.isLoggedIn()) { return true; }
        return false;
    }

    /**
     * WHEN
     * the routing to the page happens
     *
     * FOR WHAT
     * to check for the token stored in the user context model
     *
     * WHY
     * to validate the user
     *
     * HOW
     * by reading the token value stored in the user context model
     */
    isLoggedIn() {
        const token = this.getAuthorizationToken();
        if (!token) {
            return false;
        }
        return true;
    }

    /**
     * FOR WHAT
     * to check for the token stored in the cookies
     *
     * WHY
     * to validate the user request
     *
     * HOW
     * by reading the token value stored in the cookies
     */
    getAuthorizationToken() {
        return this.config.apiKey;
    }
}

