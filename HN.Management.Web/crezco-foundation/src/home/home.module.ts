import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { SharedModule } from 'src/shared/shared.module';

@NgModule({
  declarations: [HomeComponent],
  imports: [SharedModule, CommonModule],
  exports: [HomeComponent],
})
export class HomeModule {}
