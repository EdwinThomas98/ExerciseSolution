import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/authentication/auth.guard';

const routes: Routes = [
  {
    path: '', loadChildren: () => import('../src/app/welcome-details/welcome-details.module').
      then(m => m.WelcomeDetailsModule)
  }, {
    path: 'userDetails', loadChildren: () => import('../src/app/user-details/user-details.module').
      then(m => m.UserDetailsModule), canActivate: [AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
