import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';
import { Login } from '../models/login.model';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginModel: Login = new Login();

  // used to help create "Login failed" alerts
  invalidLogin: boolean = false;

  constructor(private loginService: LoginService, private router: Router, private jwtHelper: JwtHelperService) { }

  ngOnInit(): void {
  }

  // calls the login service, passing the username and password values from the view to it. Sets the JWT token if successful.
  login(username: string, password: string): void {
    this.invalidLogin = false;
    this.loginModel.username = username;
    this.loginModel.password = password;
    this.loginService.login(this.loginModel).subscribe(response => {
      const token = (<any>response).token;
      localStorage.setItem('jwt', token);
      this.invalidLogin = false;
      this.router.navigate(['/']);
    }, err => {
      this.invalidLogin = true;
    });
  }
}
