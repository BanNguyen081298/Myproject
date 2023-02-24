import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-home-layout',
  templateUrl: './home-layout.component.html',
  styleUrls: ['./home-layout.component.css'],
})
export class HomeLayoutComponent implements OnInit {
  user = {
    name: 'Abc',
    addr: 'Địa chỉ abc',
  };
  constructor(private _toastr: ToastrService) {}

  ngOnInit(): void {
    // this._toastr.success('Success', 'User Master');
    // this._toastr.info('info', 'User Master');
    // this._toastr.warning('warning', 'User Master');
    // this._toastr.error('error', 'User Master');
    // Swal.fire('Hello');
  }
}
