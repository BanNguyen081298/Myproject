import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoriesComponent } from './categories.component';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  declarations: [CategoriesComponent],
  imports: [FormsModule, MatTableModule, BrowserModule],
})
export class CategoriesModule {}
