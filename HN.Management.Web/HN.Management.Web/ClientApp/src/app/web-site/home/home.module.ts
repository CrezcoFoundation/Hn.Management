import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

// Custom imports from Projects Folder
import { HomeComponent } from './home.component';
import { SharedModule } from 'src/app/web-site/shared/shared.module';
//Sweet alert
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';

@NgModule({
  declarations: [HomeComponent],
  imports: [
    SharedModule,
    RouterModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    SweetAlert2Module,
  ],
  exports: [HomeComponent],
})
export class HomeModule {}
