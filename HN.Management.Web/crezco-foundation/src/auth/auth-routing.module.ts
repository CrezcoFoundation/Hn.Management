import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { AuthRoutes } from './auth-routes';

const routes: Routes = [
  {
    path: '',
    component: AuthComponent,
    children: AuthRoutes,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes), ReactiveFormsModule],
  exports: [RouterModule],
})
export class AuthRoutingModule {}
