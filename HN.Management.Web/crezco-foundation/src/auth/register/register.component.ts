import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  userName: string = '';
  userLastName: string = '';
  userEmail: string = '';
  password: string = '';

  register() {
    // TODO: Here can add the logic to send form data to the server
  }
}
