import { Component, Inject, OnInit } from '@angular/core';
import { Film } from '../../films/films.model';
import { Reservation } from '../reservations.model';
import { ReservationsService } from '../reservations.service';


@Component({
  selector: 'app-list-reservations',
  templateUrl: './reservations-list.component.html',
  styleUrls: ['./reservations-list.component.css']
})
export class ReservationsListComponent implements OnInit {

  public reservations: Reservation[];

  constructor(private reservationsService: ReservationsService) {

  }

  getReservations() {
    this.reservationsService.getReservations().subscribe(
      r => {
        this.reservations = r;
        //this.films = r.films;
  });
  }

  ngOnInit() {
    this.getReservations();
  }

}
