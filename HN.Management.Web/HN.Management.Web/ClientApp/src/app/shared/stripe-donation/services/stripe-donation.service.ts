import { donationDetails } from '../interfaces/donationDetails';
import { donationModel } from '../interfaces/donationModel';
import { Donor } from '../interfaces/donor.interface';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StripeDonationService {

  baseURL = '/api';

  constructor(private httpClient: HttpClient) { }

  createDonor(donor: Donor): Observable<Donor> {
    return this.httpClient.post<Donor>(`${this.baseURL}/Payment/customer`, donor)
  }

  createPriceOneTime(price: donationDetails): Observable<donationDetails> {
    return this.httpClient.post<donationDetails>(`${this.baseURL}/Payment/price`, price,
    )
  }

  createPriceRecurring(prices: donationModel): Observable<donationModel> {
    return this.httpClient.post<donationModel>(`${this.baseURL}/Payment/price`, prices,
    )
  }


  testtingService(price: donationDetails, prices: donationModel){
    console.log(price);
    console.log(prices);
    return 'price';
  }
}
