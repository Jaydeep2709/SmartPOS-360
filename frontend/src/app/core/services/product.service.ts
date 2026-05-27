// import { Injectable } from '@angular/core';
// import { PRODUCTS } from '../data/data';

// @Injectable({
//   providedIn: 'root'
// })
// export class ProductService {

//   products = [...PRODUCTS];

//   getProducts() {
//     return this.products;
//   }

//   addProduct(product: any) {
//     this.products.push(product);
//   }

//   deleteProduct(id: number) {
//     this.products = this.products.filter(x => x.id !== id);
//   }

//   updateStock(id: number, status: boolean) {
//     const product = this.products.find(x => x.id === id);

//     if (product) {
//       product.inStock = status;
//     }
//   }
// }

import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import {
  catchError,
  Observable,
  throwError
} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiUrl = 'https://fakestoreapi.com/products';

  constructor(
    private http: HttpClient
  ) {}

  getProducts(): Observable<any[]> {

    return this.http.get<any[]>(this.apiUrl).pipe(

      catchError((error) => {

        console.error('API Error:', error);

        return throwError(() =>
          new Error('Failed to fetch products')
        );

      })

    );

  }

}