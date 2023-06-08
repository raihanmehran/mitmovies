import { Component, Input, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-cast-tv-detail',
  templateUrl: './cast-tv-detail.component.html',
  styleUrls: ['./cast-tv-detail.component.css']
})
export class CastTvDetailComponent implements OnInit {
  @Input() credits: any;
  imageUrl = environment.imageUrl;

  constructor() {}

  ngOnInit(): void {}
}