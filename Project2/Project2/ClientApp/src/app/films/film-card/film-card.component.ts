import { Component, OnInit, Input } from '@angular/core';
import { Film, Comment } from '../films.model';
import { FilmsService } from "../films.service";


@Component({
  selector: 'app-film-card',
  templateUrl: './film-card.component.html'
})
export class FilmCardComponent implements OnInit {

  @Input('comment') comment: Comment[];


  constructor(private filmsService: FilmsService) { }

  ngOnInit(): void {
  }

  

}
