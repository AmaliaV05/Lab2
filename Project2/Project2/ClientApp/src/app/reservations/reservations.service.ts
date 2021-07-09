import { HttpClient } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Reservation } from './reservations.model';

@Injectable({
  providedIn: 'root'
})
export class ReservationsService {
  reservations: any;
  private apiUrl: string;

  constructor(private httpClient: HttpClient, @Inject('API_URL') apiUrl: string) {
    this.apiUrl = apiUrl;
  }

  getReservations() {
    return this.httpClient.get<Reservation[]>(this.apiUrl + 'reservation');
    //this.httpClient.get('https://localhost:5001/reservations');
  }

}

