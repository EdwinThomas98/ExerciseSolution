import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WelcomeDetailsRoutingModule } from './welcome-details.routing.module';
import { WelcomeDetailsComponent } from './welcome-details.component';


@NgModule({
  declarations: [WelcomeDetailsComponent],
  imports: [
    CommonModule,
    WelcomeDetailsRoutingModule
  ]
})
export class WelcomeDetailsModule { }
