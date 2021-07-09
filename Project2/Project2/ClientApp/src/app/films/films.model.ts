import { Reservation } from "../reservations/reservations.model";

export class Film {
  id: number;
  title: string;
  description: string;
  genre: Genre;
  duration: string;
  yearOfRelease: number;
  director: string;
  dateAdded: string;
  rating: number;
  watched: string;
  reservations: Reservation[];
}

export enum Genre {
  Action,
  Comedy,
  Horror,
  Thriller
}

export const GENRE = ['Action', 'Comedy', 'Horror', 'Thriller'];
