import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Reservation } from '../reservations.model';
import { ReservationsService } from '../reservations.service';


@Component({
  selector: 'app-list-reservations',
  templateUrl: './reservations-list.component.html',
  styleUrls: ['./reservations-list.component.css']
})
export class ReservationsListComponent {

  //reservations: Reservation[];
  reservations: any;

  constructor(private reservationsService: ReservationsService) {

  }

  getReservations() {
   return this.reservationsService.getReservations().subscribe(
      r => {
        this.reservations = r;
      }, error => {
        console.log(error);
      })
  }

  ngOnInit() {
    this.getReservations();
  }

}
