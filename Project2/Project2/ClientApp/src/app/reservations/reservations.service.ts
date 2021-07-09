import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Reservation } from './reservations.model';

const baseUrl = 'https://localhost:5001/api/reservation';

@Injectable(

)
export class ReservationsService {
  API_URL = 'https://localhost:5001/';
  private apiUrl: string;

  constructor(private httpClient: HttpClient, @Inject('API_URL') apiUrl: string) {
    this.apiUrl = apiUrl;
  }


  get(path: string, params?: any): Observable<any> {
    const headers = this.getHeaders();
    return this.httpClient.get(`${this.API_URL}${path}`, {
      headers,
      params: this.toHttpParams(params),
    });
  }

  post(path: string, body = {}): Observable<any> {
    const headers = this.getHeaders();
    return this.httpClient.post(
      `${this.API_URL}${path}`,
      JSON.stringify(body),
      { headers }
    );
  }

  put(path: string, body = {}): Observable<any> {
    const headers = this.getHeaders();
    return this.httpClient.put(`${this.API_URL}${path}`, JSON.stringify(body), {
      headers,
    });
  }

  delete(path: string, params?: any): Observable<any> {
    const headers = this.getHeaders();
    return this.httpClient.delete(`${this.API_URL}${path}`, {
      headers,
      params: this.toHttpParams(params),
    });
  }

  getR(id: any): Observable<any> {
    return this.httpClient.get(`${baseUrl}/${id}`);
  }
  update(id, data): Observable<any> {
    return this.httpClient.put(`${baseUrl}/${id}`, data);
  }

  private getHeaders() {
    const headers = {
      Accept: 'application/json',
      'Content-Type': 'application/json',
    } as any;

    return headers;
  }

  private toHttpParams(params): HttpParams {
    if (!params) {
      return new HttpParams();
    }
    return Object.getOwnPropertyNames(params).reduce(
      (p, key) => p.set(key, params[key]),
      new HttpParams()
    );
  }

}


