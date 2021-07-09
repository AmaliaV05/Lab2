import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { FilmsService } from '../films.service';
import { Film, GENRE, Comment } from '../films.model';


@Component({
  selector: 'app-comment-add',
  templateUrl: 'comment-add.component.html'
})

export class CommentAddComponent implements OnInit {
  modalRef: BsModalRef;
  comment: Comment;

  constructor(
    private filmsService: FilmsService,
    private router: Router,
    private modalService: BsModalService) { }

  ngOnInit() {
    
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }


  
}
