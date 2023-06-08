import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-recommendations-movie-detail',
  templateUrl: './recommendations-movie-detail.component.html',
  styleUrls: ['./recommendations-movie-detail.component.css'],
})
export class RecommendationsMovieDetailComponent implements OnInit {
  @Input() recommendations: any;
  imageUrl = environment.imageUrl;
  mediaTypeId: number | undefined;

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.setMediaType();
  }

  getPopularity(avgVote: number) {
    if (avgVote) return Math.floor((avgVote / 10) * 100);
    return 0;
  }

  setMediaType() {
    if (this.recommendations.length > 0)
      this.mediaTypeId = this.recommendations.mediaType;
  }

  getMediaType() {
    return this.mediaTypeId;
  }

  getRouterLink() {
    if (this.mediaTypeId === 1) return 'movies/';
    return 'tv/';
  }
}
