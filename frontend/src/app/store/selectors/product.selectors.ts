import {
  createFeatureSelector,
  createSelector
} from '@ngrx/store';

export const selectProductState =
  createFeatureSelector<any>('products');

export const selectProducts =
  createSelector(

    selectProductState,

    state => state.products

  );

export const selectLoading =
  createSelector(

    selectProductState,

    state => state.loading

  );