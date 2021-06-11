import { Component, OnInit } from '@angular/core';
import { Movie } from '../models/movie.model';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styles: [
  ]
})
export class MovieComponent implements OnInit {

  constructor(private movieService: MovieService) { }

  // the view iterates over this list to create a bootstrap card with the movie info
  movieList: Movie[] = [];

  ngOnInit(): void {
    this.getMovies();
  }

  // fetches list of all movies in DB through the API
  getMovies(): void {
    this.movieService.getMovies().subscribe(movies => {
      this.movieList = movies;

      console.log(movies);
    });
  }
}
