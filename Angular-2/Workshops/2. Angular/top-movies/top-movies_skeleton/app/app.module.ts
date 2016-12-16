import { SortPipe } from './pipes/sort-pipe';
import { MovieComponent } from './movie/movie.component';
import { MovieListComponent } from './movie/movies-list.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';

import { Ng2BootstrapModule } from 'ng2-bootstrap/ng2-bootstrap';

@NgModule({
    imports: [BrowserModule,
        HttpModule],
    declarations: [
        AppComponent,
        MovieListComponent,
        MovieComponent,

        SortPipe
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
