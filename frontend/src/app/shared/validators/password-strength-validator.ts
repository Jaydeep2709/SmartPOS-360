import {
  AbstractControl,
  ValidationErrors,
  ValidatorFn
} from '@angular/forms';

export function passwordStrengthValidator(): ValidatorFn {

  return (
    control: AbstractControl
  ): ValidationErrors | null => {

    const value = control.value;

    if (!value) {

      return null;

    }

    const hasUpperCase =
      /[A-Z]/.test(value);

    const hasNumber =
      /[0-9]/.test(value);

    const hasSpecialChar =
      /[!@#$%^&*(),.?":{}|<>]/.test(value);

    const validPassword =
      hasUpperCase &&
      hasNumber &&
      hasSpecialChar;

    return validPassword
      ? null
      : { passwordStrength: true };

  };

}