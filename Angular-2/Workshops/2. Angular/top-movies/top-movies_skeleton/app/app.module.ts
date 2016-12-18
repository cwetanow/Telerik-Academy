import { MovieSortPipe } from './pipes/sort-pipe';
import { MovieFilterPipe } from './pipes/filter-pipe';

import { MovieComponent } from './movie/movie.component';
import { MovieListComponent } from './movie/movies-list.component';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';

import { Ng2BootstrapModule } from 'ng2-bootstrap/ng2-bootstrap';

@NgModule({
    imports: [BrowserModule,
        HttpModule,
        FormsModule
    ],
    declarations: [
        AppComponent,
        MovieListComponent,
        MovieComponent,

        MovieSortPipe,
        MovieFilterPipe
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
