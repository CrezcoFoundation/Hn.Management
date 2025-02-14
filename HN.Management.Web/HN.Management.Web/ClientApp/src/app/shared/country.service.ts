// src/app/services/country-states.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CountryStatesService {

  private jsonUrl = 'assets/countries/country_states.json';

  constructor(private http: HttpClient) { }

  // Método para obtener los países
  getCountries(): Observable<any> {
    return this.http.get(this.jsonUrl);
  }
}
