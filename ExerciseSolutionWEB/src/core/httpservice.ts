import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserDetailsModel } from 'src/app/user-details/user-details.model';

@Injectable({
    providedIn: 'root'
})

export class HttpService {
    httpOptions: any;

    constructor(private http: HttpClient) {
    }

    /**
     * WHEN
     * the get call is used in the serive.ts files
     *
     * WHY
     * to get the required information from the api
     */
    get(url: any) {
        return this.http.get(url);
    }

    /**
     * WHEN
     * the post call is used in the serive.ts files
     *
     * WHY
     * to save the required information to the api
     *
     */
    post(url: any, data: any) {
        return this.http.post(url, data);
    }
}
