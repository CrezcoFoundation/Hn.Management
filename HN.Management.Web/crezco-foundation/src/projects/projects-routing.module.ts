import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [ 
  { path: 'products', loadChildren: () => import('./projects-routes').then(m => m.ProjectsRoutes) } 
];

@NgModule({
  imports: [RouterModule.forChild(routes), ReactiveFormsModule],
  exports: [RouterModule],
})
export class ProjectsRoutingModule {}



