import { NgModule, isDevMode } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// custom
import { SharedModule } from 'src/shared/shared.module';
import { HomeModule } from 'src/home/home.module';
import { GiveModule } from 'src/give/give.module';
import { CrezcoStoryModule } from 'src/crezco-story/crezco-story.module';
import { ContactUsModule } from 'src/contact-us/contact-us.module';
import { StoreModule } from '@ngrx/store';
import { crezcoReducers, metaReducers } from './reducers';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

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
    StoreModule.forRoot(crezcoReducers, {
      metaReducers,
    }),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: !isDevMode() }),
  ],
})
export class AppModule {}
