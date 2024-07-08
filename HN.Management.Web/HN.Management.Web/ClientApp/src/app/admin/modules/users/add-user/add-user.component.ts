import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoleService } from 'src/app/admin/services/role.service';
import { User } from 'src/app/admin/interfaces/user';
import { Role } from 'src/app/admin/interfaces/role';
import { UserService } from 'src/app/admin/services/user.service';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { first } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-user',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss'],
  
})
export class AddUserComponent {
  role:Role= {
    id: '',
    name: '',
    isDeleted: false,
  };
  form!: FormGroup;
  id: string = '';
  isAddMode: boolean = false;
  fieldTextType: boolean = false;
  error: any;
  user: User = {
    isDeleted: false,
    email: '',
    username: '',
    isEmailConfirmed: false,
    password: '',
    role: this.role
  }
  roles?: Role[];
  loading = false;
  submitted = false;
  roleSelected?: Role[];
  
  constructor( 
    private formBuilder: FormBuilder, 
    private userService: UserService, 
    private roleService: RoleService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.id = this.route.snapshot.params['id'];
    this.isAddMode = !this.id;
    this.getRoles();

    this.form = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      role: ['', Validators.required],
    });

    if(!this.isAddMode){
      this.userService.getById(this.id)
      .pipe(first())
      .subscribe(x => this.form.patchValue(x))
    }
  }

  get f(){
    return this.form!.controls;
  }

  toggleFieldTextType(): void {
    this.fieldTextType = !this.fieldTextType;
  }

  getRoles() {
    this.roleService.getAll().pipe(first()).subscribe( roles => {
      this.roles = roles;
    });
  }
  
  getRoleById(id: string){
    this.roleService.getById(id).pipe(first()).subscribe( roles => {
      this.roleSelected = roles;
      console.log(`roles: ${roles}`);
      console.log(`roleSelected: ${this.roleSelected}`);
      
    });
  }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.form.invalid) {
        return;
    }

    this.getRoleById(this.f['role'].value);
    console.log(`Este es el rol: ${this.role}`);

    this.loading = true;
    if (this.isAddMode) {
        this.createUser();
    } else {
        this.updateUser();
    }
}

private createUser() {
  // stop if form is invalid
  if(this.form!.invalid){
    return;
  }

  
  
  // assign values from registerForm to user
  this.user.email = this.f['email'].value;
  this.user.username = `${this.f['firstName'].value} ${this.f['lastName'].value}`;
  this.user.password = 'donordonor';
  this.user.role!.id = this.f['role'].value;
  this.user.role!.name = this.role.name;

    this.userService.create(this.user)
        .pipe(first())
        .subscribe({
            next: () => {
                this.router.navigate(['../'], { relativeTo: this.route });
            }
        });
}

private updateUser() {
    this.userService.update(this.user)
        .pipe(first())
        .subscribe({
            next: () => {
                this.router.navigate(['../../'], { relativeTo: this.route });
            }
        });
}


  onAddUser() {
    
    // stop if form is invalid
    if(this.form!.invalid){
      return;
    }

    // assign values from registerForm to user
    this.user.email = this.f['email'].value;
    this.user.username = `${this.f['firstName'].value} ${this.f['lastName'].value}`;
    this.user.password = 'donordonor';
    this.user.role!.id = this.f['role'].value;

    this.userService.create(this.user)
    .pipe(first())
    .subscribe(
      _data => {
        this.router.navigate(['admin/users']);
      },
      _error => {
        this.error = _error;
      }
    )


  }

}
