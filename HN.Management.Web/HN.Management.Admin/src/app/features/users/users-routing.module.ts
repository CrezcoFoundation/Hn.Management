import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersComponent } from './users.component';
import { PageNotFoundComponent } from '../../core/components/page-not-found/page-not-found.component';
import { NewUserComponent } from './new-user/new-user.component';
import { UpdateUserComponent } from './update-user/update-user.component';
import { RolesComponent } from './roles/roles.component';
import { NewRoleComponent } from './new-role/new-role.component';
import { UpdateRoleComponent } from './update-role/update-role.component';
import { AssignPrivilegeComponent } from './roles/assign-privilege/assign-privilege.component';

const routes: Routes = [
  { path: '', component: UsersComponent },
  { path: 'add-user', component: NewUserComponent },
  { path: 'edit-user/:id', component: UpdateUserComponent },
  { path: 'roles', component: RolesComponent },
  { path: 'add-role', component: NewRoleComponent },
  { path: 'edit-role/:id', component: UpdateRoleComponent },
  { path: 'assign-pivileges/:id', component: AssignPrivilegeComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
