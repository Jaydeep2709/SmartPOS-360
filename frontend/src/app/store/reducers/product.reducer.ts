import {
  createReducer,
  on
} from '@ngrx/store';

import * as ProductActions
from '../actions/product.actions';

import {
  initialState
} from '../models/product.state';

export const productReducer = createReducer(

  initialState,

  on(ProductActions.loadProducts, state => ({

    ...state,

    loading: true

  })),

  on(ProductActions.loadProductsSuccess,

    (state, action) => ({

      ...state,

      loading: false,

      products: action.products

    })

  ),

  on(ProductActions.loadProductsFailure,

    (state, action) => ({

      ...state,

      loading: false,

      error: action.error

    })

  )

);