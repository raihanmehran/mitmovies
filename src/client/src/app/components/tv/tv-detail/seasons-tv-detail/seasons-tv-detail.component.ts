import { Component, Input, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-seasons-tv-detail',
  templateUrl: './seasons-tv-detail.component.html',
  styleUrls: ['./seasons-tv-detail.component.css'],
})
export class SeasonsTvDetailComponent implements OnInit {
  @Input() seasons: any[] = [];
  imageUrl = environment.imageUrl;

  constructor() {}

  ngOnInit(): void {}
}
