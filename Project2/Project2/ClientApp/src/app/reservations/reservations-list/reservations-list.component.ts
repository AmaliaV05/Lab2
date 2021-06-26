import { Component } from '@angular/core';
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
    this.reservationsService.getReservations().subscribe(
      r => {
        this.reservations = r;
  });
  }

  ngOnInit() {
    this.getReservations();
  }

}
