import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RoleService } from 'src/app/admin/services/role.service';
import { User } from 'src/app/admin/interfaces/user';
import { Role } from 'src/app/admin/interfaces/role';
import { UserService } from 'src/app/admin/services/user.service';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { first } from 'rxjs';

@Component({
  selector: 'app-add-user',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss'],
  
})
export class AddUserComponent {
  role:Role= {
    name: '',
    isDeleted: false,
  };
  addUserForm!: FormGroup;
  fieldTextType: boolean = false;
  router: any;
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
  
  constructor( 
    private formBuilder: FormBuilder, 
    private userService: UserService, 
    private roleService: RoleService 
  ) {}

  ngOnInit() {

    this.getRoles();

    this.addUserForm = this.formBuilder.group({
      userFirstName: ['', Validators.required],
      userLastName: ['', Validators.required],
      userEmail: ['', Validators.required],
      userRoleId: ['', Validators.required],
      userRole: ['', Validators.required],
    });
  }

  get f(){
    return this.addUserForm!.controls;
  }

  toggleFieldTextType(): void {
    this.fieldTextType = !this.fieldTextType;
  }

  getRoles() {
    this.roleService.getAll().pipe(first()).subscribe( roles => {
      this.roles = roles;
    });
  }
  

  onAddUser() {
    
    // stop if form is invalid
    if(this.addUserForm!.invalid){
      return;
    }

    // assign values from registerForm to user
    this.user.email = this.f['userEmail'].value;
    this.user.username = `${this.f['userFirstName'].value} ${this.f['userLastName'].value}`;
    this.user.password = 'donordonor';
    this.user.role!.name = this.f['userRole'].value;

    this.userService.createUser(this.user)
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
