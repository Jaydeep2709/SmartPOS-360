import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponentsModule } from './dashboard.module';
import { StatCard }
from './components/stat-card/stat-card';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    StatCard,
    DashboardComponentsModule
  ],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss'
})
export class Dashboard {

}