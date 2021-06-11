import { Component } from '@angular/core';
import { faVideo, faUserNinja } from '@fortawesome/free-solid-svg-icons';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  // angular font awsome components
  faVideo = faVideo;
  faUserNinja = faUserNinja;

  constructor(private jwtHelper: JwtHelperService) { }

  // this is used to control what parts of the website are shown
  isUserAuthenticated() {
    const token = localStorage.getItem('jwt');

    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    } else {
      return false;
    }
  }

  logOut() {
    localStorage.removeItem('jwt');
  }
}
