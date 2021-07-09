import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Film, GENRE, Comment, FilmWithComments } from '../films.model';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { FilmsService } from '../films.service';


@Component({
  selector: 'app-film-page',
  templateUrl: 'film-page.component.html'
})
export class FilmPageComponent implements OnInit {
  GENRE = GENRE;
  film = new Film();
  filmWithComments = new Film();
  modalRef: BsModalRef;
  newComment = new Comment();

  constructor(private apiSvc: FilmsService,
    private route: ActivatedRoute,
    private modalService: BsModalService,
    private router: Router) { }

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

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
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

  postComment() {
    this.apiSvc.post(`api/film/${this.film.id}/Comments`, this.newComment).subscribe(
      () => {
        this.router.navigateByUrl(`film-with-comments/${this.film.id}/${this.film.title}`);
      }
    );
  }
  
}
