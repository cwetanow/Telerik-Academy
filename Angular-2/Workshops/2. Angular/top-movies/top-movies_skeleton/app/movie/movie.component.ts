import { Component, Input } from '@angular/core';
import { Movie } from '../core/models/movie';


@Component({
    selector: '[movie]',
    templateUrl: 'movie.component.html'
})
export class MovieComponent {
    @Input() movie: any;

    constructor() {
    }
}