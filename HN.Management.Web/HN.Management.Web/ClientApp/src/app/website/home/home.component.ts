import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContactEmailsService } from 'src/app/website/contact-us/contact-emails.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  // @ts-ignoretypes
  newsletterForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private contactEmailService: ContactEmailsService
  ) {}

  ngOnInit() {
    this.newsletterForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
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

    this.onResetForm();
  }

  onSubmited() {

    this.contactEmailService
      .sendNewsLetterEmail(this.newsletterForm.value)
      .subscribe(
        () => {
          this.showAlert();
          this.onResetForm();
        },
        (error) => {
          console.error('Error sending email', error);
        }
      );
  }

  onResetForm() {
    this.newsletterForm.reset({});
  }
}
