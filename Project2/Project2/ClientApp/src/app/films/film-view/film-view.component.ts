import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Film } from '../films.model';
import { FilmsService } from '../films.service';

@Component({
  selector: 'app-films-list-view',
  templateUrl: 'film-view.component.html',
  encapsulation: ViewEncapsulation.None
})
export class FilmsListViewComponent implements OnInit {
  films: Array<Film>;

  constructor(private apiSvc: FilmsService, private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.loadFilms();
  }

  private loadFilms() {
    this.apiSvc.get('api/film').subscribe((response: Array<Film>) => {
      this.films = response;
    });
  }
}
