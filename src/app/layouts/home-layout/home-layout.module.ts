import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeLayoutRoutes } from './home-layout.routing';

@NgModule({
  imports: [RouterModule.forChild(HomeLayoutRoutes)],
  declarations: [],
})
export class HomeLayoutModule {}
