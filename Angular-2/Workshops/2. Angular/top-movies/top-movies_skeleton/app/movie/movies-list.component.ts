import { MovieModel } from './../core/models/movie';
import { Component, OnInit, Inject, ChangeDetectionStrategy } from '@angular/core';
import { Http, Response } from '@angular/http';
import { MoviesService } from '../core/services/movie-service';

@Component({
    templateUrl: 'movies-list.component.html'
})
export class MovieListComponent implements OnInit {
    movies: MovieModel[];
    pageTitle: string;

    filterProperty: string;
    sortingWay: number;
    sortingProperty: string;

    constructor(private moviesService: MoviesService) {
        this.filterProperty = '';
        this.sortingWay = 1;
        this.sortingProperty = "Title";
    }

    ngOnInit() {
        this.moviesService.getMovies()
            .map((res: Response) => res.json())
            .subscribe(
            (res) => {
                this.movies = res;
            });
    };

    onWayChange(event: any) {
        this.sortingWay = +event.target.value;
    }

    onSortingChange(event: any) {
        this.sortingProperty = event.target.value;
    }
}

