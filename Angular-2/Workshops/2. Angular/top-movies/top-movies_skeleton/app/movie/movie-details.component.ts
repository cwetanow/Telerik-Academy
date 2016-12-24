import { MovieModel } from './../core/models/movie';
import { MoviesService } from './../core/services/movie-service';
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: './movie-details.component.html'
})
export class MovieDetailsComponent implements OnInit {
    movie: MovieModel;
    title: string;

    constructor(private movieService: MoviesService, private route: ActivatedRoute) {
        this.movie = this.movie || new MovieModel();
    }

    ngOnInit() {
        this.route.params
            .subscribe(params => {
                this.title = params['title'];

                this.movieService.getMovieByTitle(this.title)
                    .subscribe(model => {
                        this.movie = model;
                    });
            });
    }
}
