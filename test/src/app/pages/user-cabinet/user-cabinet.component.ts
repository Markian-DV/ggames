import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user-cabinet',
  templateUrl: './user-cabinet.component.html',
  styleUrls: ['./user-cabinet.component.scss']
})
export class UserCabinetComponent implements OnInit {

  userToken: string;

  constructor() {
    this.userToken = localStorage.getItem('userToken');
  }

  ngOnInit(): void {
    // this.getInfoByToken(this.userToken);
    // console.log(localStorage.getItem('userToken'));
  }

}
