import { MovieModel } from './../core/models/movie';
import { Component, OnInit, Inject, ChangeDetectionStrategy } from '@angular/core';
import { Http, Response } from '@angular/http';

@Component({
    selector: 'movies-list',
    templateUrl: 'movies-list.component.html'
})
export class MovieListComponent implements OnInit {
    movies: MovieModel[];
    pageTitle: string;

    filterProperty: string;
    sortingWay: number;
    sortingProperty: string;

    constructor(private http: Http) {
        this.filterProperty = '';
        this.sortingWay = 1;
        this.sortingProperty = "Title";
    }

    ngOnInit() {
        this.http.get('../data/movies.json')
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