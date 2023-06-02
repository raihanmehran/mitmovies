import { Component, OnInit } from '@angular/core';
import { Movie } from 'src/app/_models/movie';
import { TrendingMoviesService } from 'src/app/_services/trending-movies.service';

@Component({
  selector: 'app-trending-movies',
  templateUrl: './trending-movies.component.html',
  styleUrls: ['./trending-movies.component.css'],
})
export class TrendingMoviesComponent implements OnInit {
  movies: Movie[] = [];

  constructor(public trendingMoviesService: TrendingMoviesService) {}

  ngOnInit(): void {
    this.getTodayTrendingMovies();
    this.trendingMoviesService.todayTrendingMovies$.subscribe({
      next: (movies) => {
        if (movies) this.movies = movies;
        console.log(this.movies);
      },
    });
  }

  getTodayTrendingMovies() {
    this.trendingMoviesService.getTodayTrendingMovies();
  }
}
