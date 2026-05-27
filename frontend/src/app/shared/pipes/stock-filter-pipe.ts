import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'stockFilter',
  standalone: true
})
export class StockFilterPipe implements PipeTransform {

  transform(products: any[], category: string): any[] {

    if (!products) {
      return [];
    }

    // Show all products
    if (
      !category ||
      category === 'ALL'
    ) {
      return products;
    }

    // Filter by category
    return products.filter(

      product =>

        product.category
          .toLowerCase()
          .includes(category.toLowerCase())

    );

  }

}