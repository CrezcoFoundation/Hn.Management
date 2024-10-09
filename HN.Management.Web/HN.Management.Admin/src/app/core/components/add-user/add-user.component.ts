import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs';
import { Role } from '../../interfaces/role';
import { User } from '../../interfaces/user';
import { UserService } from '../../services/user.service';
import { RoleService } from '../../services/role.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html'
})
export class AddUserComponent implements OnInit {
  
  newUserForm =  new FormGroup({
    email: new FormControl,
    userName: new FormControl,
    roleId: new FormControl,
    roleName: new FormControl,
    file: new FormControl, 
    password: new FormControl
  });
  
  fileName = '';

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

  formdata: any;

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
      roleName: [''],
      file: [''],
      password: ['']
    });

    this.getRoles();

    this.formdata = new FormData();

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

  onFileSelected(event: any): void {

    const file:File = event.target.files[0];

    if (file) {

        this.fileName = file.name;

        this.formdata.append("file", file);
    }
}

  onSubmited() {

    this.submitted = true;

    // stop here if form is invalid
    if (this.newUserForm.invalid) {
      return;
    }

    this.loading = true;

    // assign values from registerForm to user
    this.formdata.append("email", this.f['email'].value);
    this.formdata.append("fullName", this.f['userName'].value);
    this.formdata.append("userName", this.f['userName'].value);
    this.formdata.append("role.Id", this.f['roleId'].value);
    this.formdata.append("role.Name", this.f['roleName'].value);
    this.formdata.append("password", this.f['password'].value);
    // this.user.email = this.f['email'].value;
    // this.user.username = this.f['userName'].value;
    // this.user.password = 'donordonor';
    // this.user.role!.id = this.f['roleId'].value;
    // this.user.role!.name = this.f['roleName'].value;

    this.userService.create(this.formdata)
        .pipe(first())
        .subscribe({
            next: () => {
                this.router.navigate(['/users'], { relativeTo: this.route });
            }
        });
  }

}
