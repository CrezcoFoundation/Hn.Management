import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  userName: string = '';
  password: string = '';

  login() {
    // TODO: Here can add the logic to send form data to the server
    console.log('Nombre de usuario:', this.userName);
    console.log('Contraseña:', this.password);
  }
}
