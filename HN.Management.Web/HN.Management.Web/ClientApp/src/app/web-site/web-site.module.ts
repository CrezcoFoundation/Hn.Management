import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WebSiteRoutingModule } from './web-site-routing.module';
import { WebSiteComponent } from './web-site.component';
import { ContactUsModule } from 'src/app/web-site/contact-us/contact-us.module';
import { CrezcoStoryModule } from 'src/app/web-site/crezco-story/crezco-story.module';
import { GiveModule } from 'src/app/web-site/give/give.module';
import { HomeModule } from 'src/app/web-site/home/home.module';
import { SharedModule } from 'src/app/web-site/shared/shared.module';


@NgModule({
  declarations: [
    WebSiteComponent
  ],
  imports: [
    ContactUsModule,
    CrezcoStoryModule,
    GiveModule,
    HomeModule,
    SharedModule,
    CommonModule,
    WebSiteRoutingModule
  ],
  exports: [
    WebSiteComponent
  ]
})
export class WebSiteModule { }
