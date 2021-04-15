import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {
  displayedColumns: string[] = ['email', 'name', 'delete'];

  adminToken: string;

  users: any[];

  constructor() {
    this.adminToken = localStorage.getItem('userToken');
  }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(): void {
    fetch('https://markianpack.azurewebsites.net/api/users', {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + this.adminToken,
        "Access-Control-Allow-Origin": "*"
      }
    })
      .then(data => data.json())
      .then(users => {
        console.log(users);
        this.users = users;
      });
  }

  deleteUser(userID: string): void {
    fetch(`https://markianpack.azurewebsites.net/api/users/${userID}`, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
        'Authorization': 'Bearer ' + this.adminToken,
        "Access-Control-Allow-Origin": "*"
      }
    })
      .then(() => this.getUsers());
  }

}
