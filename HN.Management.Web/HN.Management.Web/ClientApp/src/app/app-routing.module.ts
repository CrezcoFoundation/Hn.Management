import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WebSiteComponent } from './web-site/web-site.component';

import {
  LocationStrategy,
  Location,
  PathLocationStrategy,
} from '@angular/common';

const routes: Routes = [
  { path: '', component: WebSiteComponent },
  { path: 'webSite', loadChildren: () => import('./web-site/web-site.module').then(m => m.WebSiteModule) },
  { path: 'admin', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule) },
  { path: '**', redirectTo: '' }
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
