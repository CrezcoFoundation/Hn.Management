import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { LoginComponent } from '../auth/login/login.component';

@NgModule({
  declarations: [LoginComponent],
  imports: [ReactiveFormsModule, RouterModule, CommonModule],
  exports: [LoginComponent],
})
export class LoginModule {}
