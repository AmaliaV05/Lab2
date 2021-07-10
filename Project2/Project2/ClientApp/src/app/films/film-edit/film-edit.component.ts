import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Film, GENRE } from '../films.model';
import { FilmsService } from '../films.service';


@Component({
  selector: 'app-edit-film',
  templateUrl: 'film-edit.component.html',
})

export class EditFilmPage implements OnInit {
  GENRE = GENRE;
  film = new Film();
  message = '';

  constructor(
    private apiSvc: FilmsService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    this.getFilm(this.route.snapshot.paramMap.get('id'));
  }

  getFilm(id): void {
    this.apiSvc.getF(id)
      .subscribe(
        data => {
          this.film = data;
        },
        error => {
          console.log(error);
        });
  }

  updateFilm(): void {
    this.apiSvc.update(this.film.id, this.film)
      .subscribe(
        response => {
          console.log(response);
          this.message = 'The film was updated successfully!';
        },
        error => {
          console.log(error);
        });
  }

}
