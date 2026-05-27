import { Component, OnInit } from '@angular/core';

import { ProductService } from '../../../../core/services/product.service';
import { Store } from '@ngrx/store';

import * as ProductActions from '../../../../store/actions/product.actions';

import * as ProductSelectors from '../../../../store/selectors/product.selectors';
@Component({
  selector: 'app-product-list',
  standalone: false,
  templateUrl: './product-list.html',
  styleUrls: ['./product-list.scss']
})
export class ProductList implements OnInit {

  products: any[] = [];

  loading = false;

  errorMessage = '';
  selectedCategory ='';
  displayedColumns: string[] = [
    'id',
    'image',
    'title',
    'category',
    'price',
    'rating',
    'actions'
  ];
products$;

  loading$;

  constructor(
    private store: Store
  ) {

    this.products$ =
      this.store.select(
        ProductSelectors.selectProducts
      );

    this.loading$ =
      this.store.select(
        ProductSelectors.selectLoading
      );

       this.products$.subscribe(data => {

    console.log('Selector Products:', data);

  });

  }
  // constructor(
  //   private productService: ProductService
  // ) {}

  ngOnInit(): void {
  console.log('Dispatching Load Products');

    this.store.dispatch(
      ProductActions.loadProducts()
    );

  }

  // loadProducts(): void {

  //   this.loading = true;

  //   this.productService.getProducts().subscribe({

  //     next: (response) => {

  //       this.products = response;

  //       console.log(this.products);

  //       this.loading = false;

  //     },

  //     error: (error) => {

  //       this.errorMessage = error.message;

  //       this.loading = false;

  //     }

  //   });

  // }

}