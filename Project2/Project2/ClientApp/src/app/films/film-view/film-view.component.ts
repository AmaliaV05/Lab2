import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FilmParams, Pagination } from '../films-list/films-pagination.model';
import { Film } from '../films.model';
import { FilmsService } from '../films.service';

@Component({
  selector: 'app-films-list-view',
  templateUrl: 'film-view.component.html',
  encapsulation: ViewEncapsulation.None
})
export class FilmsListViewComponent implements OnInit {
  films: Array<Film>;
  pagination: Pagination;
  filmParams: FilmParams;
  film2: Film;

  constructor(private filmsService: FilmsService, private router: Router,
    private route: ActivatedRoute) {
    this.filmParams = new FilmParams(this.film2);
  }

  ngOnInit() {
     this.getFilms();
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
