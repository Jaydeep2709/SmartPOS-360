import { Routes } from '@angular/router';
import {Login} from './features/auth/login/login'
import { AuthLayout } from './layouts/auth-layout/auth-layout';
import { Dashboard } from './features/dashboard/dashboard/dashboard';
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
        component: Login
      }

    ],
  },
  {
    path: 'dashboard',
    component: Dashboard,

  }

];
