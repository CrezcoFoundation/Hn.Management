import { Component } from '@angular/core';

@Component({
  selector: 'app-forgot',
  templateUrl: './forgot.component.html',
  styleUrls: ['./forgot.component.scss'],
})
export class ForgotComponent {
  emailName: string = '';

  forgot() {
    // TODO: Here can add the logic to send form data to the server
    console.log('Correo electrónico:', this.emailName);
  }
}
