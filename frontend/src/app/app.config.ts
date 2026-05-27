import { ApplicationConfig, provideBrowserGlobalErrorListeners, provideZonelessChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { provideStore } from '@ngrx/store';
import { provideEffects } from '@ngrx/effects';
import { productReducer } from './store/reducers/product.reducer';
import { ProductEffects } from './store/effects/product.effects';
import { provideStoreDevtools } from '@ngrx/store-devtools';
import { routes } from './app.routes';
import {
  localStorageSync
} from 'ngrx-store-localstorage';

export function localStorageSyncReducer(
  reducer: any
): any {

  return localStorageSync({

    keys: ['products'],

    rehydrate: true

  })(reducer);

}

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    //provideZonelessChangeDetection(),
    provideRouter(routes),
    provideHttpClient(),
    provideStore({

    products: productReducer

  },
{

    metaReducers: [
      localStorageSyncReducer
    ]

  }),

  provideEffects([
    ProductEffects
  ]),

  provideStoreDevtools()

  ]
};
