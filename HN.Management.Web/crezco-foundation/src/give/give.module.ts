import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { GiveComponent } from './give/give.component';
import { GiveOptionsComponent } from './give-options/give-options.component';

@NgModule({
  declarations: [GiveComponent, GiveOptionsComponent],
  imports: [ReactiveFormsModule, RouterModule, CommonModule],
  exports: [GiveComponent, GiveOptionsComponent],
})
export class GiveModule {}
