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
    console.log('God Morgen');

    this.getUpcomingMovies();
  }

  getUpcomingMovies() {
    console.log('Hi');

    this.upcomingMoviesService.getUpcomingMovies();
    console.log('bye');

    this.upcomingMoviesService.upcomingMovies$.subscribe({
      next: (movies) => {
        console.log('hi again');

        console.log(movies);
        if (movies) this.movies = movies;
      },
      error: (error) => this.toastr.error(error.error, 'ERROR'),
    });
  }
}
