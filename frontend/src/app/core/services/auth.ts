// import { Injectable } from '@angular/core';
// import { Router } from '@angular/router';
// import { USERS } from '../data/data';
// @Injectable({
//   providedIn: 'root',
// })
// export class Auth {
  
//   constructor(private router: Router) {}

//   login(email: string, password: string, rememberMe: boolean): boolean {

//     const user = USERS.find(
//       x => x.email === email && x.password === password
//     );

//     if (user) {

//       localStorage.setItem('isLoggedIn', 'true');

//       if (rememberMe) {
//         localStorage.setItem('rememberedEmail', email);
//       } else {
//         localStorage.removeItem('rememberedEmail');
//       }

//       localStorage.setItem('currentUser', JSON.stringify(user));

//       return true;
//     }

//     return false;
//   }

//   logout() {

//     localStorage.removeItem('isLoggedIn');
//     localStorage.removeItem('currentUser');

//     this.router.navigate(['/login']);
//   }

//   getRememberedEmail(): string {

//     return localStorage.getItem('rememberedEmail') || '';
//   }

//   isLoggedIn(): boolean {

//     return localStorage.getItem('isLoggedIn') === 'true';
//   }

// }


// // import { Injectable } from '@angular/core';
// // import { Router } from '@angular/router';
// // import { HttpClient } from '@angular/common/http';
// // import { tap } from 'rxjs/operators';

// // @Injectable({
// //   providedIn: 'root',
// // })
// // export class Auth {

// //   private apiUrl = 'https://reqres.in/api/login';

// //   constructor(
// //     private router: Router,
// //     private http: HttpClient
// //   ) {}

// //   login(username: string, password: string, rememberMe: boolean) {

// //     return this.http.post<any>(this.apiUrl, {
// //       username,
// //       password
// //     }).pipe(
// //       tap((res) => {

// //         // ✅ store token
// //         localStorage.setItem('token', res.token);

// //         localStorage.setItem('isLoggedIn', 'true');

// //         if (rememberMe) {
// //           localStorage.setItem('rememberedUser', username);
// //         } else {
// //           localStorage.removeItem('rememberedUser');
// //         }
// //       })
// //     );
// //   }

// //   logout() {

// //     localStorage.removeItem('token');
// //     localStorage.removeItem('isLoggedIn');
// //     localStorage.removeItem('currentUser');

// //     this.router.navigate(['/login']);
// //   }

// //   getRememberedUser(): string {
// //     return localStorage.getItem('rememberedUser') || '';
// //   }

// //   isLoggedIn(): boolean {
// //     return localStorage.getItem('isLoggedIn') === 'true';
// //   }

// //   getToken(): string | null {
// //     return localStorage.getItem('token');
// //   }
// // }



import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Auth {

  private apiUrl = 'https://localhost:44313/api/Auth';

  constructor(
    private router: Router,
    private http: HttpClient
  ) {}

  // ✅ LOGIN API CALL
  login(email: string, password: string, rememberMe: boolean): Observable<any> {

    return this.http.post<any>(`${this.apiUrl}/login`, {
      email,
      password
    }).pipe(
      tap((res) => {

        // ✅ store JWT token
        localStorage.setItem('accessToken', res.accessToken);
        localStorage.setItem('refreshToken', res.refreshToken);

        localStorage.setItem('isLoggedIn', 'true');

        // optional remember username/email
        if (rememberMe) {
          localStorage.setItem('rememberedUser', email);
        } else {
          localStorage.removeItem('rememberedUser');
        }

        // optional user info
        localStorage.setItem('currentUser', JSON.stringify(res.user));
      })
    );
  }

  // ✅ LOGOUT
  logout() {

    localStorage.removeItem('accessToken');
    localStorage.removeItem('refreshToken');
    localStorage.removeItem('isLoggedIn');
    localStorage.removeItem('currentUser');

    this.router.navigate(['/login']);
  }

  // ✅ helpers
  getToken(): string | null {
    return localStorage.getItem('accessToken');
  }

  getRefreshToken(): string | null {
    return localStorage.getItem('refreshToken');
  }

  getRememberedUser(): string {
    return localStorage.getItem('rememberedUser') || '';
  }

  isLoggedIn(): boolean {
    return localStorage.getItem('isLoggedIn') === 'true';
  }
}