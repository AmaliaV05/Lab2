import { Film } from "../films.model";



export class FilmParams {
  titleFilter: string;
  pageNumber = 1;
  pageSize = 5;

  constructor(film: Film) {
    this.titleFilter = "";
  }
}



export interface Pagination {
  currentPage: number;
  itemsPerPage: number;
  totalItems: number;
  totalPages: number;
}



export class PaginatedResult<T> {
  result: T;
  pagination: Pagination;
}


