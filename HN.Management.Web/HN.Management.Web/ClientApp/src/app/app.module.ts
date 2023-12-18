import { NgModule, isDevMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';

// custom
import { SharedModule } from 'src/app/web-site/shared/shared.module';
import { HomeModule } from 'src/app/web-site/home/home.module';
import { GiveModule } from 'src/app/web-site/give/give.module';
import { CrezcoStoryModule } from 'src/app/web-site/crezco-story/crezco-story.module';
import { ContactUsModule } from 'src/app/web-site/contact-us/contact-us.module';
import { StoreModule } from '@ngrx/store';
import { crezcoReducers, metaReducers } from './reducers';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { WebSiteModule } from './web-site/web-site.module';

@NgModule({
  declarations: [AppComponent],
  providers: [],
  bootstrap: [AppComponent],
  imports: [
    WebSiteModule,
    ContactUsModule,
    CrezcoStoryModule,
    GiveModule,
    HomeModule,
    SharedModule,
    BrowserModule,
    AppRoutingModule,
    StoreModule.forRoot(crezcoReducers, {
      metaReducers,
    }),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: !isDevMode() }),
    ReactiveFormsModule,
  ],
})
export class AppModule {}
