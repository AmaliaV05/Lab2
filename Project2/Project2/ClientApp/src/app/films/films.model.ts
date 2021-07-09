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
  comments: Comment[];
}

export enum Genre {
  Action,
  Comedy,
  Horror,
  Thriller
}

export const GENRE = ['Action', 'Comedy', 'Horror', 'Thriller'];

export class Comment {
  id: number;
  text: string;
  important: string;
}

export interface FilmWithComments {
  id: number;
  title: string;
  description: string;
  rating: number;
  watched: string;
  comments: Comment[];
}
