import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { FilmParams, PaginatedResult } from './films-list/films-pagination.model';
import { Film } from './films.model';

const baseUrl = 'https://localhost:5001/api/film';

@Injectable(

)
export class FilmsService {
  API_URL = 'https://localhost:5001/';
  private apiUrl: string;

  constructor(private httpClient: HttpClient, @Inject('API_URL') apiUrl: string) {
    this.apiUrl = apiUrl;
  }

  /*getFilms(): Observable<Film[]> {
    return this.httpClient.get<Film[]>(this.apiUrl + 'film');
  }*/

  getFilms(filmParams: FilmParams) {

    let params = this.getPaginationHeaders(filmParams.pageNumber, filmParams.pageSize);

    params = params.append('title', filmParams.titleFilter);

    return this.getPaginatedResult<Film[]>(this.apiUrl + 'film', params);
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

  getF(id: any): Observable<any> {
    return this.httpClient.get(`${baseUrl}/${id}`);
  }
  update(id, data): Observable<any> {
    return this.httpClient.put(`${baseUrl}/${id}`, data);
  }

  getComments(id: any): Observable<any> {
    return this.httpClient.get(`${baseUrl}/${id}/Comments`);
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

  private getPaginatedResult<T>(url, params) {
    const paginatedResult: PaginatedResult<T> = new PaginatedResult<T>();
    return this.httpClient.get<T>(url, { observe: 'response', params }).pipe(
      map(response => {
        paginatedResult.result = response.body;
        if (response.headers.get('Pagination') !== null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return paginatedResult;
      }));
  }

  private getPaginationHeaders(pageNumber: number, pageSize: number) {
    let params = new HttpParams();

    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());

    return params;
  }
}
