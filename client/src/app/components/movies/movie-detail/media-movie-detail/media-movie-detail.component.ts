import { Component, Input, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

let apiLoaded = false;
@Component({
  selector: 'app-media-movie-detail',
  templateUrl: './media-movie-detail.component.html',
  styleUrls: ['./media-movie-detail.component.css'],
})
export class MediaMovieDetailComponent implements OnInit {
  @Input() videos: any;
  @Input() images: any;

  imageUrl = environment.imageUrl;

  constructor() {}

  ngOnInit(): void {
    if (!apiLoaded) this.loadiFrameAPI();
  }

  loadiFrameAPI() {
    const tag = document.createElement('script');
    tag.src = 'https://www.youtube.com/iframe_api';
    document.body.appendChild(tag);

    apiLoaded = true;
  }
}
