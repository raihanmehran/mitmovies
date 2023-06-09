import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MoviesService } from 'src/app/_services/movies.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.css'],
})
export class SearchResultComponent implements OnInit {
  movies: any[] = [];
  tvShows: any[] = [];
  imageUrl = environment.imageUrl;
  selectedTab: string = 'movies';

  constructor(
    private route: ActivatedRoute,
    private moviesService: MoviesService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      const searchQuery = params['query'];
      this.selectedTab = 'movies';
      if (searchQuery) {
        console.log(searchQuery);

        this.getSearchResult(searchQuery);
      } else console.log('Empty');
    });
  }

  getSearchResult(query: string) {
    this.searchMovies(query);
  }

  searchMovies(query: string) {
    this.moviesService.searchMovies(query).subscribe({
      next: (results) => {
        this.movies = results;
        console.log(this.movies);
      },
      error: (error) => this.toastr.error(error.error, 'ERROR'),
    });
  }

  selectTab(requestedtab: string) {
    this.selectedTab = requestedtab;
  }
}
