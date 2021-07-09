import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Film } from '../films.model';
import { FilmsService } from '../films.service';
import { Router } from '@angular/router';
import { PaginatedResult, Pagination, FilmParams } from './films-pagination.model';


@Component({
  selector: 'app-list-films',
  templateUrl: './films-list.component.html',
  styleUrls: ['./films-list.component.css']
})
export class FilmsListComponent {

  films: Film[];
  pagination: Pagination;
  filmParams: FilmParams;
  film2: Film;

  constructor(private filmsService: FilmsService, private router: Router) {
    this.filmParams = new FilmParams(this.film2);
  }

/*  getFilms() {
    this.filmsService.getFilms().subscribe(p => this.films = p);
  }*/

  ngOnInit() {
    this.getFilms();
  }

  goToAddFilm() {
    this.router.navigateByUrl('films/add');
  }

  deleteFilm(film: Film) {
    this.filmsService.delete(`api/film/${film.id}`).subscribe(() => {
      this.getFilms();
    });
  }

   getFilms() {
    this.filmsService.getFilms(this.filmParams).subscribe(response => {
      this.films = response.result;
      this.pagination = response.pagination;
    })
   }

  resetFilters() {
    this.filmParams = new FilmParams(this.film2);
    this.getFilms();
  }

  pageChanged(event: any) {
    this.filmParams.pageNumber = event.page;
    this.getFilms();
  }
}
