import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'sort'
})
export class SortPipe implements PipeTransform {
    transform(items: any[], ) {
        return items.sort();
    }
};