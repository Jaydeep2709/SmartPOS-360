import { Component, HostListener } from '@angular/core';
import { LayoutService } from '../../../core/services/layout.service';
import { Footer } from '../../footer/footer';
import { Header } from '../../header/header';
import { RouterOutlet } from '@angular/router';
import { Sidebar } from '../../sidebar/sidebar';
import { Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-vertical-layout',
  standalone: true,
  templateUrl: './vertical-layout.html',
  styleUrl: './vertical-layout.scss',
  imports: [Footer, Header,RouterOutlet,Sidebar,AsyncPipe]
})
export class VerticalLayout {

    sidebarOpen$: Observable<boolean>;


  constructor(private layoutService: LayoutService) {
    this.sidebarOpen$ = this.layoutService.sidebarOpen$;
    this.checkScreen(window.innerWidth);
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    this.checkScreen(event.target.innerWidth);
  }

  private checkScreen(width: number) {
    const isMobile = width <= 768;
    this.layoutService.setMobileMode(isMobile);
  }
}