import { CommonModule } from '@angular/common';
import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { ContactEmailsService } from 'src/app/website/contact-us/contact-emails.service';
import Swal from 'sweetalert2';
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
    private contactEmailService: ContactEmailsService,){ }

  ngOnInit() {
    this.authService.setIsNavFooter(true);
    this.authService.getIsNavFooter;
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
