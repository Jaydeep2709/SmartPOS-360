import { Routes } from '@angular/router';
import {Login} from './features/auth/login/login'
import { AuthLayout } from './layouts/auth-layout/auth-layout';
import { VerticalLayout } from './layouts/main-layout/vertical-layout/vertical-layout';
import { ProductList } from './features/dashboard/components/product-list/product-list';
import { loginGuard } from './core/guards/login-guard';
import { authGuard } from './core/guards/auth-guard';

export const routes: Routes = [

 {
    path: '',
    component: AuthLayout,
    children: [

      {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
      },

      {
        path: 'login',
        component: Login,
        canActivate: [loginGuard]

      }

    ],
  },
  {
    path: '',
    component: VerticalLayout,
    children: [
      {
        path: 'dashboard',
         canActivate: [authGuard],
        // component: Dashboard
        loadComponent: () =>

          import(
            './features/dashboard/dashboard'
          ).then(m => m.Dashboard)
      },
      {
        path: 'productList',
        canActivate: [authGuard],
        component: ProductList
      }
    ]
  }


];
