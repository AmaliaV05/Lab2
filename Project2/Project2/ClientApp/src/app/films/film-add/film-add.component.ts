import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Film, GENRE } from '../films.model';
import { FilmsService } from '../films.service';

@Component({
  selector: 'film-add',
  templateUrl: 'film-add.component.html',
})

export class FilmAddComponent {
  GENRE = GENRE;

  film = new Film();

  constructor(
    private apiSvc: FilmsService,
    private router: Router
  ) { }

  addFilm() {
    this.apiSvc.post('api/film', this.film).subscribe(
      () => {
        this.router.navigateByUrl('films');
      }
    );
  }

  backToFilms() {
    this.router.navigateByUrl('films');
  }
}
