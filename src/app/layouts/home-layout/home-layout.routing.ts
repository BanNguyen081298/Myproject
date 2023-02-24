import { Routes } from '@angular/router';
import { CategoriesComponent } from 'src/app/modules/categories/categories.component';
import { LoginComponent } from 'src/app/modules/login/login.component';
import { ProductsComponent } from 'src/app/modules/products/products.component';
export const HomeLayoutRoutes: Routes = [
  {
    path: 'categories',
    component: CategoriesComponent,
  },
  {
    path: 'products',
    component: ProductsComponent,
  },
];
