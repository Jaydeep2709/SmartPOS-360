import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponentsModule } from './dashboard.module';
import { StatCard }
from './components/stat-card/stat-card';
import { TranslatePipe } from '@ngx-translate/core';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    StatCard,
    DashboardComponentsModule,
    TranslatePipe
  ],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss'
})
export class Dashboard {

}