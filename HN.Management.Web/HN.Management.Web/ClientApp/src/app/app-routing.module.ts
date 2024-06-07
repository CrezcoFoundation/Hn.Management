/* import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactUsComponent } from 'src/app/website/contact-us/contact-us/contact-us.component';
import { CrezcoStoryComponent } from 'src/app/website/crezco-story/crezco-story/crezco-story.component';
import { GiveComponent } from 'src/app/website/give/give/give.component';
import { HomeComponent } from 'src/app/website/home/home.component';

import {
  LocationStrategy,
  Location,
  PathLocationStrategy,
} from '@angular/common';

const routes: Routes = [
  { path: 'contact-us', component: ContactUsComponent },
  { path: 'crezco-story', component: CrezcoStoryComponent },
  { path: 'give', component: GiveComponent },
  {
    path: 'auth',
    loadChildren: () => import('../app/core/auth/auth.module').then((m) => m.AuthModule),
  },
  {
    path: 'projects',
    loadChildren: () =>
      import('../app/website/projects/projects.module').then((m) => m.ProjectsModule),
  },
  { path: '', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'top'})],
  exports: [RouterModule],
  providers: [
    Location,
    { provide: LocationStrategy, useClass: PathLocationStrategy },
  ],
})
export class AppRoutingModule {}
 */
