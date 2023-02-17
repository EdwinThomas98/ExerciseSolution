import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../authentication/auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private auth: AuthService) {
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // Get the auth token from the service.
        const authToken = this.auth.getAuthorizationToken();
        // Clone the request and set the new header in one step.
        const authReq = req.clone({ setHeaders: { Authorization: authToken } });
        // Pass on the cloned request instead of the original request.
        return next.handle(authReq);
    }

}