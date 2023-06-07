import { Component, Input, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-cast-movie-detail',
  templateUrl: './cast-movie-detail.component.html',
  styleUrls: ['./cast-movie-detail.component.css'],
})
export class CastMovieDetailComponent implements OnInit {
  @Input() credits: any;
  imageUrl = environment.imageUrl;

  constructor() {}

  ngOnInit(): void {}
}
