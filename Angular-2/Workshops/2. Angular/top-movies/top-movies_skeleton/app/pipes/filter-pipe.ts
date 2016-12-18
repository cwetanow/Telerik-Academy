import { MovieModel } from './../core/models/movie';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'movieFilterPipe'
})

export class MovieFilterPipe implements PipeTransform {
    transform(movies: MovieModel[], filter: string): any {
        if (movies) {
            return movies.filter(m => {
                return m.Title
                    .toLocaleLowerCase()
                    .indexOf(filter) > -1;
            });
        }
    }
}