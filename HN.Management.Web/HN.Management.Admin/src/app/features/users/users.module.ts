import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';
import { UsersComponent } from './users.component';
import { NewUserComponent } from './new-user/new-user.component';
import { UpdateUserComponent } from './update-user/update-user.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RolesComponent } from './roles/roles.component';
import { UpdateRoleComponent } from './update-role/update-role.component';
import { NewRoleComponent } from './new-role/new-role.component';
import { AssignPrivilegeComponent } from './roles/assign-privilege/assign-privilege.component';
import { CoreModule } from "../../core/core.module";


@NgModule({
  declarations: [
    UsersComponent,
    NewUserComponent,
    UpdateUserComponent,
    RolesComponent,
    UpdateRoleComponent,
    NewRoleComponent,
    AssignPrivilegeComponent
  ],
  imports: [
    CommonModule,
    UsersRoutingModule,
    ReactiveFormsModule,
    CoreModule
],
  exports: [
    UsersComponent
  ]
})
export class UsersModule { }
