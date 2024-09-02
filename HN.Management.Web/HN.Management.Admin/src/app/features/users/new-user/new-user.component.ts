import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Role } from '../../../core/interfaces/role';
import { User } from '../../../core/interfaces/user';
import { RoleService } from '../../../core/services/role.service';
import { UserService } from '../../../core/services/user.service';
import { first } from 'rxjs';

@Component({
  selector: 'app-new-user',
  templateUrl: './new-user.component.html'
})
export class NewUserComponent implements OnInit{
  
  newUserForm =  new FormGroup({
    email: new FormControl,
    userName: new FormControl,
    roleId: new FormControl,
    roleName: new FormControl
  });

  role:Role= {
    id: '',
    name: '',
    isDeleted: false,
  };

  fieldTextType: boolean = false;
  roles?: Role[];
  loading = false;
  submitted = false;
  error: any;

  user: User = {
    isDeleted: false,
    email: '',
    username: '',
    isEmailConfirmed: false,
    password: '',
    role: this.role,
    id: ''
  }

 constructor(
  private formBuilder: FormBuilder, 
  private userService: UserService, 
  private roleService: RoleService,
  private router: Router, 
  private route: ActivatedRoute
  ) {}
  
  ngOnInit(): void {
    this.newUserForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      userName: ['', Validators.required],
      roleId: ['', Validators.required],
      roleName: ['']
    });

    this.getRoles();

  }

  get f(){
    return this.newUserForm!.controls;
  }

  toggleFieldTextType(): void {
    this.fieldTextType = !this.fieldTextType;
  }

  getRoles() {
    this.roleService.getAll().pipe(first()).subscribe( roles => {
      this.roles = roles;
    });
  }

  updateRoleSelector(event: any): void {
    let roleName = event.target.options[event.target.options.selectedIndex].text;
    this.newUserForm.controls.roleName.setValue(roleName);
  }

  onSubmited() {

    this.submitted = true;

    // stop here if form is invalid
    if (this.newUserForm.invalid) {
      return;
    }

    this.loading = true;

    // assign values from registerForm to user
    this.user.email = this.f['email'].value;
    this.user.username = this.f['userName'].value;
    this.user.password = 'donordonor';
    this.user.role!.id = this.f['roleId'].value;
    this.user.role!.name = this.f['roleName'].value;

    this.userService.create(this.user)
        .pipe(first())
        .subscribe({
            next: () => {
                this.router.navigate(['/users'], { relativeTo: this.route });
            }
        });
  }

}
