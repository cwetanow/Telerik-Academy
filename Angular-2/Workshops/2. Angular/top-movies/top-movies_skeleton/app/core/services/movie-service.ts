import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class MoviesService {

    constructor(private http: Http) { }

    getMovies(): Observable<any> {
        return this.http.get('../data/movies.json');
    }
}