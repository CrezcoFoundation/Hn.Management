import { NgModule } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { CrezcoStoryComponent } from './crezco-story/crezco-story.component';

@NgModule({
  declarations: [CrezcoStoryComponent],
  imports: [CommonModule, NgOptimizedImage],
  exports: [CrezcoStoryComponent],
})
export class CrezcoStoryModule {}
