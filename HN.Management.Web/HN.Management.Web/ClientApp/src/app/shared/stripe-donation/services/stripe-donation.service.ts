import { donationDetails } from './../intefaces/donationDetails';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Donor } from '../intefaces/donor';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StripeDonationService {

  baseURL = 'https://crezcofoundation.org/api';

  constructor(private httpClient: HttpClient) { }

  createDonor(donor: Donor): Observable<Donor> {
    return this.httpClient.post<Donor>(`${this.baseURL}/Payment/customer`, donor)
  }
//
  createPrice(price: donationDetails): Observable<donationDetails> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
    });
    const options = {headers}
    return this.httpClient.post<donationDetails>(`${this.baseURL}/Payment/price`, price, options
    )
  }


  testtingService(price: donationDetails){
    console.log(price);
    return 'price';
  }
}
