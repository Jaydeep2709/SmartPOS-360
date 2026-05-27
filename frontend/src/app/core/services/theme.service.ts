import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class ThemeService {

  private dark = false;

  toggleTheme() {
    this.dark = !this.dark;

    if (this.dark) {
      document.body.classList.add('dark-theme');
    } else {
      document.body.classList.remove('dark-theme');
    }
  }

  isDark() {
    return this.dark;
  }
}