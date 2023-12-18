import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmailInterface } from './email-interface';
import { environment } from 'src/environments/environment';

import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root',
})
export class ContactEmailsService {


  /* showAlert() {
    Swal.fire({
      position: 'center',
      icon: 'error',
      title: 'Http failure response for http://localhost:34698/api/mail/contact-me: 0 Unknown Error',
      showConfirmButton: false,
      timer: 2000,
    });
  } */



  baseUrl = environment.api_url;
  mailControllerBase= '/api/mail';
  newsLetterProgram= '/newsletter-program';
  contactMe = '/contact-me';

  newsLetterEmailRequest = `${this.baseUrl}${this.mailControllerBase}${this.newsLetterProgram}`
  contactMeRequest = `${this.baseUrl}${this.mailControllerBase}${this.contactMe}`

  constructor(private http: HttpClient) {}

  sendEmail = (emailContent: EmailInterface) => { 
    /* this.showAlert(); */
    return this.http.post(this.contactMeRequest, emailContent);
  };
}
