import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  baseUrl = environment.apiUrl;
  title = 'MitMovies';
  users: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get(this.baseUrl + 'weatherforecast').subscribe({
      next: (response) => (this.users = response),
      error: (error) => console.log(error),
      complete: () => console.log('done'),
    });
  }
}
