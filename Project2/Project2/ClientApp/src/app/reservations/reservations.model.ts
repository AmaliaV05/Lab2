import { Film } from "../films/films.model";

export class Reservation {
  applicationUser: ApplicationUser;
  films: Film[];
  reservationDateTime: string;
}

export class ApplicationUser {
  email: string;
}
