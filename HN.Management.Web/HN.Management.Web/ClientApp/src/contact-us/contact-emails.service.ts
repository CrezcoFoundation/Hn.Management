import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmailInterface } from './email-interface';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ContactEmailsService {
  baseUrl = environment.api_url;
  mailControllerBase= '/api/mail';
  newsLetterProgram= '/newsletter-program';
  contactMe = '/contact-me';

  newsLetterEmailRequest = `${this.baseUrl}${this.mailControllerBase}${this.newsLetterProgram}`
  contactMeRequest = `${this.baseUrl}${this.mailControllerBase}${this.contactMe}`

  constructor(private http: HttpClient) {}

  sendEmail = (emailContent: EmailInterface) => { 
    return this.http.post(this.contactMeRequest, emailContent);
  };
}
