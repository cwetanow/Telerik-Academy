import { MovieModel } from './../core/models/movie';
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'moviesSortPipe'
})
export class MovieSortPipe implements PipeTransform {
    transform(movies: MovieModel[], options: any[]) {
        if (options && movies) {
            return movies.sort((a, b) => {
                switch (options[0]) {
                    case 'Title':
                        return options[1] > 0 ?
                            a.Title.localeCompare(b.Title) :
                            b.Title.localeCompare(a.Title);
                    case 'Rating':
                        return options[1] > 0 ?
                            +a.imdbRating - +b.imdbRating :
                            +b.imdbRating - +a.imdbRating;
                    case 'Year':
                        return options[1] > 0 ?
                            +a.Year - +b.Year :
                            +b.Year - +a.Year;
                }
            });
        }

        return movies;
    }
};