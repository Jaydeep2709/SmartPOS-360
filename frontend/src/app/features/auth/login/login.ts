import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';
import { HighlightDirective } from '../../../shared/directives/highlight'; 
import { Auth } from '../../../core/services/auth';
import { Router } from '@angular/router';
import { passwordStrengthValidator } from '../../../shared/validators/password-strength-validator';
import { MatFormFieldModule }
from '@angular/material/form-field';

import { MatInputModule }
from '@angular/material/input';

import { MatButtonModule }
from '@angular/material/button';

import { MatCheckboxModule }
from '@angular/material/checkbox';

import { MatCardModule }
from '@angular/material/card';

import { MatIconModule }
from '@angular/material/icon';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, 
            ReactiveFormsModule, 
            FormsModule, 
            HighlightDirective,
           MatFormFieldModule,
            MatInputModule,
            MatButtonModule,
            MatCheckboxModule,
            MatCardModule,
            MatIconModule],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {

  rememberMe = false;
  loginForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private authService: Auth,
    private router: Router
  ) {

    // Initialize form FIRST
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6), passwordStrengthValidator()]]
    });

    // Then use patchValue
    const rememberedEmail = this.authService.getRememberedEmail();

    if (rememberedEmail) {

      this.loginForm.patchValue({
        email: rememberedEmail
      });

      this.rememberMe = true;
    }
  }

  onSubmit() {

  if (this.loginForm.valid) {

    const { email, password } = this.loginForm.value;

    const success = this.authService.login(
      email,
      password,
      this.rememberMe
    );

    if (success) {

      this.router.navigate(['/dashboard']);
      console.log('success')

    } else {

      alert('Invalid Credentials');

    }

  } else {

    this.loginForm.markAllAsTouched();

  }

}
}


// import { Component } from '@angular/core';
// import { CommonModule } from '@angular/common';
// import {
//   FormBuilder,
//   FormGroup,
//   FormsModule,
//   ReactiveFormsModule,
//   Validators
// } from '@angular/forms';

// import { Router } from '@angular/router';
// import { Auth } from '../../../core/services/auth';
// import { passwordStrengthValidator } from '../../../shared/validators/password-strength-validator';

// import { MatFormFieldModule } from '@angular/material/form-field';
// import { MatInputModule } from '@angular/material/input';
// import { MatButtonModule } from '@angular/material/button';
// import { MatCheckboxModule } from '@angular/material/checkbox';
// import { MatCardModule } from '@angular/material/card';
// import { MatIconModule } from '@angular/material/icon';

// @Component({
//   selector: 'app-login',
//   standalone: true,
//   imports: [
//     CommonModule,
//     ReactiveFormsModule,
//     FormsModule,
//     MatFormFieldModule,
//     MatInputModule,
//     MatButtonModule,
//     MatCheckboxModule,
//     MatCardModule,
//     MatIconModule
//   ],
//   templateUrl: './login.html',
//   styleUrl: './login.scss',
// })
// export class Login {

//   rememberMe = false;
//   loginForm: FormGroup;

//   constructor(
//     private fb: FormBuilder,
//     private authService: Auth,
//     private router: Router
//   ) {

//     this.loginForm = this.fb.group({
//       email: ['', [Validators.required, Validators.email]],
//       password: [
//         '',
//         [
//           Validators.required,
//           Validators.minLength(6),
//           //passwordStrengthValidator()
//         ]
//       ]
//     });

//     const rememberedUser = this.authService.getRememberedUser();

//     if (rememberedUser) {
//       this.loginForm.patchValue({
//         email: rememberedUser
//       });

//       this.rememberMe = true;
//     }
//   }

//   onSubmit() {

//     if (this.loginForm.invalid) {
//       this.loginForm.markAllAsTouched();
//       return;
//     }

//     const { email, password } = this.loginForm.value;

//     // 🔥 FIX: Observable login
//     this.authService.login(email, password, this.rememberMe)
//       .subscribe({
//         next: (res) => {
//           console.log('Login success:', res);

//           this.router.navigate(['/dashboard']);
//         },

//         error: (err) => {
//           console.error('Login failed:', err);
//           alert('Invalid credentials');
//         }
//       });
//   }
// }