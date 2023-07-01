import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { MoviesService } from 'src/app/_services/movies.service';
import { TvService } from 'src/app/_services/tv.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.css'],
})
export class SearchResultComponent implements OnInit {
  searchForm: FormGroup = new FormGroup({});
  movies: any[] = [];
  tvShows: any[] = [];
  imageUrl = environment.imageUrl;
  selectedTab: string = 'movies';

  constructor(
    private route: ActivatedRoute,
    private moviesService: MoviesService,
    private tvService: TvService,
    private toastr: ToastrService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.route.params.subscribe((params) => {
      const searchQuery = params['query'];
      if (searchQuery) {
        this.getSearchResult(searchQuery);
      } else console.log('Empty');
    });
  }

  getSearchResult(query: string) {
    this.searchMovies(query);
    this.searchTvShows(query);
  }

  searchMovies(query: string) {
    this.moviesService.searchMovies(query).subscribe({
      next: (results) => {
        this.movies = results;
      },
      error: (error) => this.toastr.error(error.error, 'ERROR'),
    });
  }

  searchTvShows(query: string) {
    this.tvService.searchTvShows(query).subscribe({
      next: (results) => {
        this.tvShows = results.results;
      },
      error: (error) => this.toastr.error(error.error, 'ERROR'),
    });
  }

  selectTab(requestedtab: string) {
    this.selectedTab = requestedtab;
  }

  initializeForm() {
    this.searchForm = this.fb.group({
      searchValue: [
        '',
        [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(100),
        ],
      ],
    });
  }

  search() {
    if (this.searchForm.valid) {
      const query = this.searchForm.controls['searchValue'].value;
      if (query) this.getSearchResult(query);
    } else if (this.searchForm.invalid)
      this.toastr.warning('Please fix the issues first');
  }
}
