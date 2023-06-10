import { Component, Input, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-cast-detail',
  templateUrl: './cast-detail.component.html',
  styleUrls: ['./cast-detail.component.css'],
})
export class CastDetailComponent implements OnInit {
  @Input() credits: any;
  imageUrl = environment.imageUrl;

  constructor() {}

  ngOnInit(): void {}
}
