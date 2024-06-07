import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink, RouterModule } from '@angular/router';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { ContactEmailsService } from 'src/app/website/contact-us/contact-emails.service';
import Swal from 'sweetalert2';
import { ContactUsModule } from '../contact-us/contact-us.module';
import { ContactUsComponent } from '../contact-us/contact-us/contact-us.component';
import { SharedBannerComponent } from "../../shared/shared-banner/shared-banner.component";

@Component({
    standalone: true,
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss'],
    imports: [
        CommonModule,
        TranslateModule,
        RouterModule,
        SharedModule,
        ContactUsModule,
        ContactUsComponent,
        ReactiveFormsModule,
        SharedBannerComponent,
    ]
})
export class HomeComponent implements OnInit {
  // @ts-ignoretypes
  newsletterForm: FormGroup;

  constructor(
    private translate: TranslateService,
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
