import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactUsComponent } from 'src/contact-us/contact-us/contact-us.component';
import { CrezcoStoryComponent } from 'src/crezco-story/crezco-story/crezco-story.component';
import { GiveComponent } from 'src/give/give/give.component';
import { LoginComponent } from 'src/login/login/login.component';
import { HomeComponent } from 'src/home/home.component';

const routes: Routes = [
  { path: 'contact-us', component: ContactUsComponent },
  { path: 'crezco-story', component: CrezcoStoryComponent },
  { path: 'give', component: GiveComponent },
  { path: 'login', component: LoginComponent },
  { path: '', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
