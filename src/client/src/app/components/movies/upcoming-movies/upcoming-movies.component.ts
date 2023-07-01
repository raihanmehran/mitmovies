import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { UpcomingMoviesService } from 'src/app/_services/upcoming-movies.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-upcoming-movies',
  templateUrl: './upcoming-movies.component.html',
  styleUrls: ['./upcoming-movies.component.css'],
})
export class UpcomingMoviesComponent implements OnInit {
  movies: any[] = [];
  imageUrl = environment.imageUrl;

  constructor(
    private upcomingMoviesService: UpcomingMoviesService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getUpcomingMovies();
  }

  getUpcomingMovies() {
    this.upcomingMoviesService.getUpcomingMovies();

    this.upcomingMoviesService.upcomingMovies$.subscribe({
      next: (movies) => {
        if (movies) this.movies = movies;
      },
      error: (error) => this.toastr.error(error.error, 'ERROR'),
    });
  }
}
