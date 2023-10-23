import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { GiveComponent } from './give/give.component';

@NgModule({
  declarations: [GiveComponent],
  imports: [ReactiveFormsModule, RouterModule, CommonModule],
  exports: [GiveComponent],
})
export class GiveModule {}
