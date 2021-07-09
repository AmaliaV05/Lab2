import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Reservation } from '../reservations.model';
import { ReservationsService } from '../reservations.service';
import { HttpResponse } from '@angular/common/http';
import { map } from "rxjs/operators";


@Component({
  selector: 'app-list-reservations',
  templateUrl: './reservations-list.component.html',
  styleUrls: ['./reservations-list.component.css']
})
export class ReservationsListComponent {

  //reservations: Reservation[];
  reservationsList: Observable<any>;

  constructor(private reservationsService: ReservationsService) {

  }

  getReservations() {
    return this.reservationsService.get('api/reservation').subscribe(
      r => {
        this.reservationsList = r;
        console.log(r);
      }, error => {
        console.log(error);
      })
  }

  ngOnInit() {
    this.getReservations();
  }

}
