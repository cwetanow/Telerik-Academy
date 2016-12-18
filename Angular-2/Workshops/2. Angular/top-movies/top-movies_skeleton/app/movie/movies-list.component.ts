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

    constructor(private http: Http) {
        this.filterProperty = '';
    }

    ngOnInit() {
        this.http.get('../data/movies.json')
            .map((res: Response) => res.json())
            .subscribe(
            (res) => {
                this.movies = res;
            });
    };

    onInput(event: any) {
        console.log(event.target.value);
    }


}