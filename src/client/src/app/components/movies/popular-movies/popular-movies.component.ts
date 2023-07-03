import { Component, OnInit } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { ToastrService } from 'ngx-toastr';
import { Movie } from 'src/app/_models/movie';
import { ResponsePagination } from 'src/app/_models/responsePagination';
import { PopularMoviesService } from 'src/app/_services/popular-movies.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-popular-movies',
  templateUrl: './popular-movies.component.html',
  styleUrls: ['./popular-movies.component.css'],
})
export class PopularMoviesComponent implements OnInit {
  movies: any[] = [];
  response: ResponsePagination | undefined;
  imageUrl = environment.imageUrl;
  currentPage = 1;

  constructor(
    private popularMoviesService: PopularMoviesService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getPopularMovies(1);
  }

  getPopularMovies(page: number) {
    this.popularMoviesService.getPopularMovies(page).subscribe({
      next: (response: any) => {
        if (response) this.setResponse(response);
      },
      error: (error) => this.toastr.error(error.error, 'ERROR'),
    });
  }

  private setResponse(response: any) {
    this.movies = response.results as Movie[];
    this.response = {
      dates: response.dates,
      page: response.page,
      totalPages: response.totalPages,
      totalResults: response.totalResults,
    };
  }

  pageChanged(event: PageChangedEvent) {
    this.getPopularMovies(event.page);
    this.scrollToTop();
  }
  scrollToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }
}
