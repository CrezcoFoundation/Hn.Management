import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgOptimizedImage } from '@angular/common';
// bootstrap components
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FullPageCarouselComponent } from './full-page-carousel/full-page-carousel.component';
import { MultipleItemsSliderComponent } from './multiple-items-slider/multiple-items-slider.component';
import { FooterComponent } from './footer/footer.component';
import { RouterModule } from '@angular/router';
import { PaypalComponent } from './donation-options/paypal/paypal.component';

@NgModule({
  declarations: [
    NavBarComponent,
    FullPageCarouselComponent,
    MultipleItemsSliderComponent,
    FooterComponent,
    PaypalComponent,
  ],
  imports: [NgOptimizedImage, RouterModule, CommonModule],
  exports: [
    PaypalComponent,
    MultipleItemsSliderComponent,
    FullPageCarouselComponent,
    FooterComponent,
    NavBarComponent,
  ],
})
export class SharedModule {}
