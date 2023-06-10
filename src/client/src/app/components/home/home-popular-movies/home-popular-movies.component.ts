import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/_models/movie';
import { PopularMoviesService } from 'src/app/_services/popular-movies.service';

@Component({
  selector: 'app-home-popular-movies',
  templateUrl: './home-popular-movies.component.html',
  styleUrls: ['./home-popular-movies.component.css'],
})
export class HomePopularMoviesComponent implements OnInit {
  popularMovies: Movie[] = [];

  constructor(public popularMoviesService: PopularMoviesService) {}

  ngOnInit(): void {
    this.getPopularMovies();
  }

  getPopularMovies() {
    this.popularMoviesService.getPopularMovies();

    this.popularMoviesService.popularMovies$.subscribe({
      next: (movies) => {
        if (movies) this.popularMovies = movies;
      },
    });
  }
}
