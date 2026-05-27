import { Component,  EventEmitter, Input, Output } from '@angular/core';
import { ChangeDetectionStrategy } from '@angular/core';
import {
  ViewChild,
  ViewContainerRef
} from '@angular/core';

import { DynamicChildComponent } from './dynamic-child.component';
@Component({
  selector: 'app-product-card',
  standalone: false,
  templateUrl: './product-card.html',
  styleUrl: './product-card.scss',
  changeDetection:
    ChangeDetectionStrategy.OnPush

})
export class ProductCard {

  @Input() product: any;

  @Output() delete = new EventEmitter<number>();

  onDelete() {
    this.delete.emit(this.product.id);
  }

    @ViewChild('dynamicHost', { read: ViewContainerRef })
  dynamicHost!: ViewContainerRef;

  loadChild() {
    this.dynamicHost.clear();

    this.dynamicHost.createComponent(DynamicChildComponent);
  }
}