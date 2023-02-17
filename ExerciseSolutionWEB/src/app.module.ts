import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { NgxConfigureModule, NgxConfigureOptions } from 'ngx-configure';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserDetailsModule } from './app/user-details/user-details.module';
import { AuthInterceptor } from './core/interceptors/authInterceptor';
import { MyOptions } from './assets/utils/base_config';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ErrorInterceptor } from './core/interceptors/errorInterceptor';
import { AuthGuard } from './core/authentication/auth.guard';
import { WelcomeDetailsModule } from './app/welcome-details/welcome-details.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    WelcomeDetailsModule,
    UserDetailsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgxConfigureModule.forRoot(),
    ToastrModule.forRoot(),
    BrowserAnimationsModule,
  ],
  providers: [HttpClient, AuthGuard,
    { provide: NgxConfigureOptions, useClass: MyOptions },
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
