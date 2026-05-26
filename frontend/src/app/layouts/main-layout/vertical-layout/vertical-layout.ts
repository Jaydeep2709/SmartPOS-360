import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';

import { Header } from '../../header/header';
import { Footer } from '../../footer/footer';
import { Sidebar } from '../../sidebar/sidebar';

@Component({
  selector: 'app-vertical-layout',
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet,
    Header,
    Footer,
    Sidebar
  ],
  templateUrl: './vertical-layout.html',
  styleUrl: './vertical-layout.scss'
})
export class VerticalLayout {

}