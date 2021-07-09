import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Film, GENRE, Comment, FilmWithComments } from '../films.model';

import { FilmsService } from '../films.service';


@Component({
  selector: 'app-film-page',
  templateUrl: 'film-page.component.html'
})
export class FilmPageComponent implements OnInit {
  GENRE = GENRE;
  film = new Film();
  filmWithComments = new Film();

  constructor(private apiSvc: FilmsService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getFilm(this.route.snapshot.paramMap.get('id'));

    let idFilm = this.route.snapshot.params.id;
    console.log(idFilm);

    this.apiSvc.getComments(idFilm).subscribe(
      data => {
        this.filmWithComments = data;
        console.log(data);
      },
      error => {
        console.log(error);
      });
  }

  getFilm(id): void {
    this.apiSvc.getF(id)
      .subscribe(
        data => {
          this.film = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  
}
