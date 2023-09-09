import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmailInterface } from './email-interface';

@Injectable({
  providedIn: 'root',
})
export class ContactEmailsService {
  baseUrl = 'http://localhost:3000';

  constructor(private http: HttpClient) {}

  sendEmail = (emailContent: EmailInterface) => {
    return this.http.post(this.baseUrl + '/employees', {
      email_content: [emailContent],
    });
  };
}
