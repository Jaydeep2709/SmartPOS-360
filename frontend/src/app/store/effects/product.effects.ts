import { Injectable, inject } from '@angular/core';

import {
  Actions,
  createEffect,
  ofType
} from '@ngrx/effects';

import {
  catchError,
  map,
  mergeMap,
  of
} from 'rxjs';

import * as ProductActions
from '../actions/product.actions';

import { ProductService }
from '../../core/services/product.service';

@Injectable()
export class ProductEffects {

  private actions$ = inject(Actions);

  private productService =
    inject(ProductService);

  loadProducts$ = createEffect(() =>

    this.actions$.pipe(

      ofType(
        ProductActions.loadProducts
      ),

      mergeMap(() =>

        this.productService
          .getProducts()
          .pipe(

            map(products =>

              ProductActions
                .loadProductsSuccess({
                  products
                })

            ),

            catchError(error =>

              of(

                ProductActions
                  .loadProductsFailure({

                    error: error.message

                  })

              )

            )

          )

      )

    )

  );

}