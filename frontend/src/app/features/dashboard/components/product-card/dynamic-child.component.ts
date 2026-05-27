import { Component } from '@angular/core';

@Component({
  selector: 'app-dynamic-child',
  standalone: true,
  template: `
    <div class="dynamic-box">
      This is dynamic child component
    </div>
  `,
  styles: [`
    .dynamic-box {
      margin-top: 10px;
      padding: 10px;
      background: #e3f2fd;
      border-left: 4px solid #1976d2;
      font-size: 13px;
    }
  `]
})
export class DynamicChildComponent {}