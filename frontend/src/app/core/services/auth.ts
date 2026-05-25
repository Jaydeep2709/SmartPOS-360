import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { USERS } from '../data/data';
@Injectable({
  providedIn: 'root',
})
export class Auth {
  
  constructor(private router: Router) {}

  login(email: string, password: string, rememberMe: boolean): boolean {

    const user = USERS.find(
      x => x.email === email && x.password === password
    );

    if (user) {

      localStorage.setItem('isLoggedIn', 'true');

      if (rememberMe) {
        localStorage.setItem('rememberedEmail', email);
      } else {
        localStorage.removeItem('rememberedEmail');
      }

      localStorage.setItem('currentUser', JSON.stringify(user));

      return true;
    }

    return false;
  }

  logout() {

    localStorage.removeItem('isLoggedIn');
    localStorage.removeItem('currentUser');

    this.router.navigate(['/login']);
  }

  getRememberedEmail(): string {

    return localStorage.getItem('rememberedEmail') || '';
  }

  isLoggedIn(): boolean {

    return localStorage.getItem('isLoggedIn') === 'true';
  }

}