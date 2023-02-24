import { Component, OnInit } from '@angular/core';

declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
}
export const ROUTES: RouteInfo[] = [
  {
    path: '/categories',
    title: 'Categories',
    icon: 'icon-chart-pie-36',
    class: '',
  },
  {
    path: '/products',
    title: 'Products',
    icon: 'icon-chart-pie-36',
    class: '',
  },
  {
    path: '/histories',
    title: 'Histories',
    icon: 'icon-chart-pie-36',
    class: '',
  },
  {
    path: '/users',
    title: 'Users',
    icon: 'icon-chart-pie-36',
    class: '',
  },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'],
})
export class SidebarComponent implements OnInit {
  menuItems: any[];
  constructor() {}

  ngOnInit() {
    this.menuItems = ROUTES.filter((menuItem) => menuItem);
  }
  isMobileMenu() {
    if (window.innerWidth > 991) {
      return false;
    }
    return true;
  }
}
