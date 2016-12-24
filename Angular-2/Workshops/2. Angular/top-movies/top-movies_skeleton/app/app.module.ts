import { NavigationComponent } from './shared/navigation.component';
import { StarRatingComponent } from './helpers/star-rating.component';
import { routing } from './app.routing';
import { MoviesService } from './core/services/movie-service';

import { MovieFilterPipe, MovieSortPipe } from './pipes';

import { MovieComponent } from './movie/movie.component';
import { MovieListComponent } from './movie/movies-list.component';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';

import { Ng2BootstrapModule } from 'ng2-bootstrap/ng2-bootstrap';
import { MovieDetailsComponent } from './movie/movie-details.component';

@NgModule({
    imports: [BrowserModule,
        HttpModule,
        FormsModule,
        routing
    ],
    declarations: [
        AppComponent,
        MovieListComponent,
        MovieComponent,
        MovieDetailsComponent,
        StarRatingComponent,
        NavigationComponent,

        MovieSortPipe,
        MovieFilterPipe
    ],
    providers: [
        MoviesService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
