import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-recommendations-detail',
  templateUrl: './recommendations-detail.component.html',
  styleUrls: ['./recommendations-detail.component.css'],
})
export class RecommendationsDetailComponent implements OnInit {
  @Input() recommendations: any;
  imageUrl = environment.imageUrl;

  constructor(private router: Router) {}

  ngOnInit(): void {}

  getPopularity(avgVote: number) {
    if (avgVote) return Math.floor((avgVote / 10) * 100);
    return 0;
  }

  getRouterLink(mediaType: number) {
    if (mediaType === 1) return 'movies/';
    else return 'tv/';
  }
}
