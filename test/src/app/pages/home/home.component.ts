import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from '../modals/login/login.component';
import { RegisterComponent } from '../modals/register/register.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {  }

  openLoginDialog():void {
    this.dialog.open(LoginComponent);
  }

  openRegisterDialog():void{
    this.dialog.open(RegisterComponent);
  }

}
