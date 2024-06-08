import { NgModule } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { CrezcoStoryComponent } from './crezco-story/crezco-story.component';

import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/locales/', '.translation.json');
}

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NgOptimizedImage,
    HttpClientModule,
  ],
  exports: [],
})
export class CrezcoStoryModule {}
