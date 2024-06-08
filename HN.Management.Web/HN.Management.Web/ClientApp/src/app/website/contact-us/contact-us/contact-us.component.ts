import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { ContactEmailsService } from '../contact-emails.service';
import { EmailInterface } from '../email-interface';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { TranslateModule } from '@ngx-translate/core';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';

@Component({
  standalone: true,
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.scss'],
  imports: [
    ReactiveFormsModule,
    CommonModule,
    FormsModule,
    SweetAlert2Module,
    HttpClientModule,
    TranslateModule
  ]
})
export class ContactUsComponent implements OnInit {

  emailCrezco: string = 'info@crezcofoundation.org';
  numberCrezco: string = '33 3333 3333 333';

  // @ts-ignoretypes
  contactForm: FormGroup;

  // Conteo de caracteres para el textArea
  textChar: string = '';
  charCount: number = 0;

  updateCharCount() {
    this.charCount = this.textChar.length;
    if (this.charCount > 200) {
      // Se limita el texto a 200 caracteres
      this.textChar = this.textChar.substring(0, 200);
      this.charCount = 200;
    }
  }

  constructor(
    private formBuilder: FormBuilder,
    private contactService: ContactEmailsService
  ) {}

  ngOnInit() {
    this.contactForm = this.formBuilder.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      message: ['', Validators.required],
      subscription: [''],
    });
  }

  showAlert() {
    Swal.fire({
      position: 'center',
      icon: 'success',
      title: 'Your message has been sent',
      showConfirmButton: false,
      timer: 2000,
    });
    this.contactForm.reset({});
    this.charCount = 0;
  }

  showAlertError() {
    Swal.fire({
      position: 'center',
      icon: 'error',
      title: 'error',
      showConfirmButton: false,
      timer: 2000,
    });
    this.contactForm.reset({});
    this.charCount = 0;
  }

  onSubmited() {
    this.contactService.sendContactEmail(this.contactForm.value).subscribe(
      (result) => {
        this.showAlert();
      },
      /* (error) => {
        this.showAlertError();
        console.error('Error sending email', error);
      } */
    );
  }
}
