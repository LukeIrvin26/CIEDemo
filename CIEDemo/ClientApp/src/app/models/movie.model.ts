export class Movie {
  id: number;
  title: string;
  yearReleased: string;
  description: string;
  imagePath: string;
  runtime: string;
  imdbLink: string;

  constructor() {
    this.id = 0;
    this.title = '';
    this.yearReleased = '';
    this.description = '';
    this.imagePath = '';
    this.runtime = '';
    this.imdbLink = '';
  }
}
