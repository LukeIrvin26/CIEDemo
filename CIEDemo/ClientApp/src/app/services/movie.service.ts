import { Injectable } from '@angular/core';
import { Movie } from '../models/movie.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../..//environments/environment';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient) { }

  readonly _baseUrl = `${environment.baseAPIUrl}/movie`;
  formData: Movie = new Movie();
  list: Movie[] = [];

  getMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(this._baseUrl).pipe(tap(_ => console.log('fetched movies OK')), catchError(this.handleError<Movie[]>('getMovies', [])));
  }

  postMovie() {
    return this.http.post(this._baseUrl, this.formData);
  }

  putMovie() {
    return this.http.put(`${this._baseUrl}/${this.formData.id}`, this.formData);
  }

  deleteMovie(id: number) {
    return this.http.delete(`${this._baseUrl}/${id}`);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      console.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    }
  }
}
