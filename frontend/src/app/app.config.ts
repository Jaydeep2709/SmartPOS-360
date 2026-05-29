import {
  ApplicationConfig,
  APP_INITIALIZER,
  importProvidersFrom,
  provideBrowserGlobalErrorListeners
} from '@angular/core';

import { provideRouter } from '@angular/router';

import {
  provideHttpClient,
  HttpClient
} from '@angular/common/http';

import {
  provideStore
} from '@ngrx/store';

import {
  provideEffects
} from '@ngrx/effects';

import {
  provideStoreDevtools
} from '@ngrx/store-devtools';

import {
  localStorageSync
} from 'ngrx-store-localstorage';

import { TranslateLoader, TranslateModule } from '@ngx-translate/core';

// import {
//   TranslateHttpLoader
// } from '@ngx-translate/http-loader';

import { routes } from './app.routes';

import {
  productReducer
} from './store/reducers/product.reducer';

import {
  ProductEffects
} from './store/effects/product.effects';

import {
  TranslationService
} from './core/services/translation.service';

import {
  TranslateHttpLoader
} from '@ngx-translate/http-loader';



// ======================
// TRANSLATE HTTP LOADER
// ======================

// export function HttpLoaderFactory(
//   http: HttpClient
// ) {

//   return new TranslateHttpLoader();

// }





// ======================
// APP INITIALIZER
// ======================

// export function initTranslations(
//   translationService: TranslationService
// ) {

//   return () => translationService.init();

// }





// ======================
// LOCAL STORAGE REDUCER
// ======================

export function localStorageSyncReducer(
  reducer: any
): any {

  return localStorageSync({

    keys: ['products'],

    rehydrate: true

  })(reducer);

}





// ======================
// APPLICATION CONFIG
// ======================

export const appConfig: ApplicationConfig = {

  providers: [

    provideBrowserGlobalErrorListeners(),

    provideRouter(routes),

    provideHttpClient(),




    // ======================
    // NGRX STORE
    // ======================

    provideStore(

      {
        products: productReducer
      },

      {
        metaReducers: [
          localStorageSyncReducer
        ]
      }

    ),

    provideEffects([
      ProductEffects
    ]),

    provideStoreDevtools(),




    // ======================
    // TRANSLATE MODULE
    // ======================

    importProvidersFrom(

      TranslateModule.forRoot({

        defaultLanguage: 'en',

        // loader: {

        //   provide: TranslateLoader,

        //   useFactory: HttpLoaderFactory,

        //   deps: [HttpClient]

        // }

      })

    ),




    // ======================
    // APP INITIALIZER
    // ======================

    // {
    //   provide: APP_INITIALIZER,

    //   useFactory: initTranslations,

    //   deps: [TranslationService],

    //   multi: true
    // }

  ]

};