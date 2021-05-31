import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Film } from './films.model';

@Component({
  selector: 'app-films',
  templateUrl: './films.component.html',
  styleUrls: ['./films.component.css']
})
export class FilmsComponent implements OnInit {

  public films: Film[]

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    http.get<Film[]>(apiUrl + 'film').subscribe(result => {
      this.films = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}
