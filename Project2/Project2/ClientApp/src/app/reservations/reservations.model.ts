import { Film } from "../films/films.model";

export class Reservation {
  id: number;
  films: Film[];
  reservationDateTime: string;
}
