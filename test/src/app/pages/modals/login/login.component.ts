import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm = new FormGroup({
    "email": new FormControl("", Validators.required),
    "password": new FormControl("", Validators.required)
  })

  constructor(
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  userLogin(): void {
    if (this.loginForm.valid) {
      fetch(
        'https://markianpack.azurewebsites.net/api/auth/login', {
        method: 'POST',
        body: JSON.stringify(this.loginForm.value),
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          "Access-Control-Allow-Origin": "*"
        }
      })
        .then(response => response.json())
        .then(data => {
          localStorage.setItem('userToken', data.token);

          let { id } = this.parseJwt(data.token);
        })
        .catch(error => console.log(error));
    }
  }

  parseJwt(token) {
    let base64Url = token.split('.')[1];
    let base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    let jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
      return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
  };

}
