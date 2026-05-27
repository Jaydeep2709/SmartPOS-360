import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'productStatus'
})
export class ProductStatusPipe implements PipeTransform {

  transform(value: boolean): string {
    return value ? 'In Stock' : 'Out of Stock';
  }

}