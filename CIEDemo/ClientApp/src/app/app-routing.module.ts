import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { LoginComponent } from './login/login.component';
import { MovieComponent } from './movie/movie.component';
import { UserComponent } from './user/user.component';
import { AuthGuardService } from './guards/auth-guard.service';

export function tokenGetter() {
  return localStorage.getItem('jwt');
}

// this is where the auth guard is applied to the routes we don't want unauthorized access to
const routes: Routes = [
  { path: '', redirectTo: '/movies', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'movies', component: MovieComponent, canActivate: [AuthGuardService] },
  {path: 'user', component: UserComponent, canActivate: [AuthGuardService] }
];

// instantiates and configures both the app routes and the jwt module that is used by the jwt auth process
@NgModule({
  imports: [RouterModule.forRoot(routes),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost: 61654']
      }
    })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
