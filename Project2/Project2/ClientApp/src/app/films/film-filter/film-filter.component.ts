import { Pipe, PipeTransform } from '@angular/core';
import { FilmParams } from '../films-list/films-pagination.model';

@Pipe({ name: 'searchFilter' })
export class FilterPipe implements PipeTransform {
  /**
   * Transform
   *
   * @param {any[]} items
   * @param {string} titleFilter
   * @returns {any[]}
   */

  filmParams: FilmParams;

  transform(items: any[], filmParams: string): any[] {
    if (!items) {
      return [];
    }
    if (!filmParams) {
      return items;
    }
    filmParams = filmParams.toLocaleLowerCase();

    return items.filter(it => {
      return it.toLocaleLowerCase().includes(filmParams);
    });
  }
}
