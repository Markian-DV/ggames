import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm = new FormGroup({
    "email": new FormControl("", Validators.required),
    "username": new FormControl("", Validators.required),
    "password": new FormControl("", Validators.required)
  })

  constructor() { }

  ngOnInit(): void {
  }

  userRegister(): void {
    if (this.registerForm.valid){
      fetch(
        'https://markianpack.azurewebsites.net/api/auth/register', {
        method: 'POST',
        body: JSON.stringify(this.registerForm.value),
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          "Access-Control-Allow-Origin": "*"
        }
      })
        .then((response) => {
          return response.json();
        })
        .then((data) => {
          if (data.errors) {
            console.log(data.errors)
            return
          }
  
          console.log(this.parseJwt(data.token));
        });
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
