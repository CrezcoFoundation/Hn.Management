import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GiveComponent } from './give/give.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [GiveComponent],
  imports: [ReactiveFormsModule, CommonModule],
  exports: [GiveComponent],
})
export class GiveModule {}
