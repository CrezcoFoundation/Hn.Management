import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { ProjectsComponent } from './projects/projects.component';
import { ProjectsRoutes } from './projects-routes';

const routes: Routes = [
  {
    path: '',
    component: ProjectsComponent,
    children: ProjectsRoutes,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes), ReactiveFormsModule],
  exports: [RouterModule],
})
export class ProjectsRoutingModule {}
