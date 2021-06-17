import { Component, Inject, OnInit } from '@angular/core';
import { Reservation } from '../reservations.model';
import { ReservationsService } from '../reservations.service';


@Component({
  selector: 'app-list-reservations',
  templateUrl: './reservations-list.component.html',
  styleUrls: ['./reservations-list.component.css']
})
export class ReservationsListComponent {

  public reservations: Reservation[];

  constructor(private reservationsService: ReservationsService) {

  }

  getReservations() {
    this.reservationsService.getReservations().subscribe(p => this.reservations = p);
  }

  ngOnInit() {
    this.getReservations();
  }

}
