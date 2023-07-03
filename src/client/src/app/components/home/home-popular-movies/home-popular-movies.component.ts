import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Movie } from 'src/app/_models/movie';
import { ResponsePagination } from 'src/app/_models/responsePagination';
import { PopularMoviesService } from 'src/app/_services/popular-movies.service';

@Component({
  selector: 'app-home-popular-movies',
  templateUrl: './home-popular-movies.component.html',
  styleUrls: ['./home-popular-movies.component.css'],
})
export class HomePopularMoviesComponent implements OnInit {
  popularMovies: Movie[] = [];
  response: ResponsePagination | undefined;
  currentPage = 1;

  constructor(
    public popularMoviesService: PopularMoviesService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getPopularMovies(1);
  }

  getPopularMovies(page: number) {
    this.popularMoviesService.getPopularMovies(page).subscribe({
      next: (response: any) => {
        if (response) {
          this.setResponse(response);
        }
      },
      error: (error) => this.toastr.error(error.error, 'ERROR'),
    });
  }

  private setResponse(response: any) {
    this.popularMovies = response.results as Movie[];
    this.response = {
      dates: response.dates,
      page: response.page,
      totalPages: response.totalPages,
      totalResults: response.totalResults,
    };
  }
}
