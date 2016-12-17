import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'moviesSortPipe',
    pure: false
})
export class SortPipe implements PipeTransform {
    transform(items: any[], options: any) {
        return items.sort();
    }
};