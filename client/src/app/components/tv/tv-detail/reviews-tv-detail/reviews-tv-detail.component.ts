import { Component, Input, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-reviews-tv-detail',
  templateUrl: './reviews-tv-detail.component.html',
  styleUrls: ['./reviews-tv-detail.component.css'],
})
export class ReviewsTvDetailComponent implements OnInit {
  @Input() reviews: any;
  imageUrl = environment.imageUrl;
  review: any;
  randomId: number = -1;

  constructor() {}

  ngOnInit(): void {
    this.getRandomReview();
  }

  getReviewDate(url: string) {
    const urlRegex = /https:\/\/\S+\/(\d{4}\/\d{2}\/\d{2})/;
    const matches = url.match(urlRegex);
    if (matches && matches.length > 0) return matches[1];
    return '';
  }

  getReviewerAvatarUrl(url: string) {
    if (url !== null)
      url.startsWith('/https:')
        ? (url = url.substring(1))
        : (url = this.imageUrl + url);
    else url = './assets/user.png';

    return url;
  }

  getRandomReview() {
    if (this.reviews.length > 0) {
      if (this.randomId === this.reviews.length - 1) this.randomId = 0;
      else this.randomId++;
      this.review = this.reviews[this.randomId];
    } else this.review = null;
  }
}
