import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { UsersModule } from './users/users.module';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    UsersModule,
    ReactiveFormsModule
  ],
  exports: [
    HomeComponent
  ]
})
export class FeaturesModule { }
