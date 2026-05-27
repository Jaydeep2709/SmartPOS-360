import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LayoutService {

  private sidebarState = new BehaviorSubject<boolean>(true);
  sidebarOpen$ = this.sidebarState.asObservable();

  toggleSidebar() {
    this.sidebarState.next(!this.sidebarState.value);
  }

  openSidebar() {
    this.sidebarState.next(true);
  }

  closeSidebar() {
    this.sidebarState.next(false);
  }

  // 👇 NEW: responsive handler
  setMobileMode(isMobile: boolean) {
    this.sidebarState.next(!isMobile); 
    // mobile => closed, desktop => open
  }
}