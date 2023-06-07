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

  constructor(private router: Router) {}

  ngOnInit(): void {}

  getPopularity(avgVote: number) {
    if (avgVote) return Math.floor((avgVote / 10) * 100);
    return 0;
  }

  getRouterLink(mediaType: number, id: number) {
    if (mediaType === 1) return 'movies/' + id;
    return 'tv/' + id;
  }
}
