import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmailInterface } from './email-interface';
import { environment } from 'src/environments/environment';
import { retry, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ContactEmailsService {
  baseUrl = environment.api_url;
  mailControllerBase = '/api/mail';
  newsLetterProgram = '/newsletter-program';
  contactMe = '/contact-me';

  newsLetterEmailRequest = `${this.baseUrl}${this.mailControllerBase}${this.newsLetterProgram}/`
  contactMeRequest = `${this.baseUrl}${this.mailControllerBase}${this.contactMe}`

  constructor(private http: HttpClient) { }

    // Http Options
    httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    };

  sendContactEmail = (emailContent: EmailInterface) => {
    return this.http.post(this.contactMeRequest, emailContent, this.httpOptions)
    .pipe(retry(1), catchError(this.handleError));
  };

  sendNewsLetterEmail = (request: any) => {
    console.log(request.email, "call service");

    return this.http.post(`${this.newsLetterEmailRequest}?email=${request.email}`, "",  this.httpOptions)
    .pipe(retry(1), catchError(this.handleError));
  };

    // Error handling
    handleError(error: any) {
      let errorMessage = '';
      if (error.error instanceof ErrorEvent) {
        // Get client-side error
        errorMessage = error.error.message;
      } else {
        // Get server-side error
        errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
      }
      window.alert(errorMessage);
      return throwError(() => {
        return errorMessage;
      });
    }
}
