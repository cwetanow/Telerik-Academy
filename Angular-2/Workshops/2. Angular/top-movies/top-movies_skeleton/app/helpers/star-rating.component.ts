import { Component, Input } from '@angular/core';

@Component({
    selector: 'star-rating',
    templateUrl: './star-rating.component.html'
})
export class StarRatingComponent {
    private stars = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

    @Input() rating: number;
}