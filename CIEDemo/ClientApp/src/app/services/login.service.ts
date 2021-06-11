import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Login } from '../models/login.model';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  readonly _baseUrl = `${environment.baseAPIUrl}/auth`;

  login(login: Login): Observable<Login> {
    return this.http.post<Login>(`${this._baseUrl}/login`, login);
  }
}
