import { CommonModule,  NgOptimizedImage } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';

// Shared components
import { FooterComponent } from '../core/layout/footer/footer.component';
import { NavBarComponent } from '../core/layout/nav-bar/nav-bar.component';
import { PaypalComponent } from './donation-options/paypal/paypal.component';
import { SharedBannerComponent } from './shared-banner/shared-banner.component';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/locales/', '.translation.json');
}

@NgModule({
  declarations: [
    NavBarComponent,
    FooterComponent,
    PaypalComponent,
    SharedBannerComponent,
  ],
  imports: [
    NgOptimizedImage,
    RouterModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
  ],
  exports: [
    PaypalComponent,
    FooterComponent,
    NavBarComponent,
    SharedBannerComponent
  ],
  bootstrap: [NavBarComponent]
})
export class SharedModule {}
