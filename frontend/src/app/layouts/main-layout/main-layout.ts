import { Component, HostListener, OnInit } from '@angular/core';
import { LayoutService } from '../../core/services/layout.service';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.html',
  styleUrls: ['./main-layout.scss']
})
export class MainLayout implements OnInit {

  constructor(private layoutService: LayoutService) {}

  ngOnInit(): void {
    this.checkScreenWidth();
  }

  @HostListener('window:resize')
  onResize() {
    this.checkScreenWidth();
  }

  checkScreenWidth() {

    if (window.innerWidth < 900) {
      this.layoutService.closeSidebar();
    } else {
      this.layoutService.openSidebar();
    }

  }
}