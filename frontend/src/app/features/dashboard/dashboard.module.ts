import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductList } from './components/product-list/product-list';
import { ProductCard } from './components/product-card/product-card';
import { ProductForm } from './components/product-form/product-form';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { FormsModule } from '@angular/forms';
import { StockFilterPipe } from '../../shared/pipes/stock-filter-pipe';
import { ProductStatusPipe } from '../../shared/pipes/product-status-pipe';

@NgModule({
  declarations: [
    ProductList,
    ProductCard,
    ProductForm,
    
  ],
  imports: [
    CommonModule,
    FormsModule,
    //ProductStatusPipe,
    StockFilterPipe,
    MatTableModule,
    MatButtonModule
  ],
  exports: [
    ProductList
  ]
})
export class DashboardComponentsModule { }