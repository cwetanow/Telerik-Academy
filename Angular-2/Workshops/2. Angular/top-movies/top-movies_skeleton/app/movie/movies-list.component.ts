import { Component, OnInit, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';

@Component({
    selector: 'movies-list',
    templateUrl: 'movies-list.component.html'
})
export class MovieListComponent implements OnInit {
    movies: any[];
    pageTitle: string;

    constructor(private http: Http) {
    }

    ngOnInit() {
        this.http.get('../data/movies.json')
            .map((res: Response) => res.json())
            .subscribe(
            (res) => {
                this.movies = res;
            });
    };
}