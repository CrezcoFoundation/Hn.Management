import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgOptimizedImage } from '@angular/common';
// bootstrap components
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FullPageCarouselComponent } from './full-page-carousel/full-page-carousel.component';
import { MultipleItemsSliderComponent } from './multiple-items-slider/multiple-items-slider.component';
import { FooterComponent } from './footer/footer.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    NavBarComponent,
    FullPageCarouselComponent,
    MultipleItemsSliderComponent,
    FooterComponent,
  ],
  imports: [NgOptimizedImage, RouterModule, CommonModule],
  exports: [
    MultipleItemsSliderComponent,
    FullPageCarouselComponent,
    FooterComponent,
    NavBarComponent,
  ],
})
export class SharedModule {}
