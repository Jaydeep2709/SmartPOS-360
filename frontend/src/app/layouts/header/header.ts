import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutService } from '../../core/services/layout.service';
import { ThemeService } from '../../core/services/theme.service';
import { Auth } from '../../core/services/auth';
import { TranslationService } from '../../core/services/translation.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './header.html',
  styleUrl: './header.scss'
})
export class Header {

  userName = 'Admin';
constructor(
    private layoutService: LayoutService, 
    private themeService: ThemeService, 
    private auth: Auth,
     private translate: TranslationService
  ) {}

  toggleSidebar() {

    this.layoutService.toggleSidebar();

  }

  toggleTheme() {
  this.themeService.toggleTheme();
}
  logout() {
    console.log('Logout clicked');
    this.auth.logout();
  }

   changeLanguage(event: Event) {

    const lang =
      (event.target as HTMLSelectElement).value;

    this.translate.setLanguage(lang);
  }

}