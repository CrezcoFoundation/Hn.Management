import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';

// custom
import { SharedModule } from 'src/shared/shared.module';
import { HomeModule } from 'src/home/home.module';
import { GiveModule } from 'src/give/give.module';
import { CrezcoStoryModule } from 'src/crezco-story/crezco-story.module';
import { ContactUsModule } from 'src/contact-us/contact-us.module';
import { AuthModule } from 'src/auth/auth.module';

@NgModule({
  declarations: [AppComponent],
  providers: [],
  bootstrap: [AppComponent],
  imports: [
    ContactUsModule,
    CrezcoStoryModule,
    GiveModule,
    HomeModule,
    SharedModule,
    BrowserModule,
    AppRoutingModule,
    AuthModule,
    ReactiveFormsModule,
  ],
})
export class AppModule {}
