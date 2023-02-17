import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WelcomeDetailsComponent } from './welcome-details.component';

const routes: Routes = [
  { path: '', component: WelcomeDetailsComponent }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})

export class WelcomeDetailsRoutingModule { }
