import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { SharedModule } from '../shared/shared.module';
import { ContactUsModule } from './contact-us/contact-us.module';
import { CrezcoStoryModule } from './crezco-story/crezco-story.module';
import { GiveModule } from './give/give.module';
import { HomeModule } from './home/home.module';
import { WebSiteRoutingModule } from './website-routing.module';

@Component({
  standalone: true,
  selector: 'appwebsite',
  templateUrl: './website.component.html',
  styleUrls: ['./website.component.scss'],
  imports: [
    HttpClientModule,
    TranslateModule,
    CommonModule,
    ContactUsModule,
    CrezcoStoryModule,
    FormsModule,
    GiveModule,
    HomeModule,
    ReactiveFormsModule,
    SharedModule,
    WebSiteRoutingModule,
  ]
})

export class WebSiteComponent {}
