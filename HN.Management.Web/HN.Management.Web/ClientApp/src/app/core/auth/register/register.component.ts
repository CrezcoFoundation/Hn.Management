import { Component } from '@angular/core';
import {
  FormGroup,
  Validators,
  FormBuilder,
} from '@angular/forms';
import { first } from 'rxjs';
import { User } from 'src/app/admin/models/user';
import { UserService } from 'src/app/admin/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  // @ts-ignoretypes
  registerForm: FormGroup;
  fieldTextType: boolean = false;
  router: any;
  error: any;
  user: User = {
    IsDeleted: false,
    Email: '',
    Username: '',
    IsEmailConfirmed: false,
    Password: '',
    Role: {
      Name: '',
      IsDeleted: false,
    }
  };

  constructor(private formBuilder: FormBuilder, private userService: UserService) {}

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      userName: ['', Validators.required],
      userLastName: ['', Validators.required],
      userEmail: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required],
    });
  }

  // convenience getter for easy access to form fields
  get f(){
    return this.registerForm.controls;
  }

  toggleFieldTextType(): void {
    this.fieldTextType = !this.fieldTextType;
  }

  onRegister() {
    
    // stop if form is invalid
    if(this.registerForm.invalid){
      return;
    }

    // assign values from registerForm to user
    //this.user.IsDeleted = false;
    this.user.Email = this.f['userEmail'].value;
    this.user.Username = `${this.f['userName'].value} ${this.f['userLastName'].value}`;
    //this.user.IsEmailConfirmed = false;
    this.user.Password = this.f['password'].value;
    this.user.Role.Name = 'Donor';
    //this.user.Role.IsDeleted = false;

    this.userService.createUser(this.user)
    .pipe(first())
    .subscribe(
      _data => {
        this.router.navigate(['auth/login']);
      },
      _error => {
        this.error = _error;
      }
    )


  }
}
