import { MovieListComponent } from './movie/movies-list.component';
import { MovieDetailsComponent } from './movie/movie-details.component';

import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';


const appRoutes: Routes = [
    //    { path: '', component: HomeComponent },
    { path: 'details/:title', component: MovieDetailsComponent },
    { path: '', component: MovieListComponent },

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);