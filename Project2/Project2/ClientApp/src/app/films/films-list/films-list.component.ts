import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Film } from '../films.model';
import { FilmsService } from '../films.service';


@Component({
  selector: 'app-list-films',
  templateUrl: './films-list.component.html',
  styleUrls: ['./films-list.component.css']
})
export class FilmsListComponent {

  public films: Film[];

  constructor(private filmsService: FilmsService) {
    
  }

  getFilms() {
    this.filmsService.getFilms().subscribe(p => this.films = p);
  }

  ngOnInit() {
    this.getFilms();
  }

}
