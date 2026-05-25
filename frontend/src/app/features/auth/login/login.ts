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

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, 
            ReactiveFormsModule, 
            FormsModule, 
            HighlightDirective],
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
      password: ['', [Validators.required, Validators.minLength(8)]]
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