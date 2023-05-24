import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { AccountService } from './_services/account.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  baseUrl = environment.apiUrl;
  title = 'MitMovies';
  users: any;
  loginForm: FormGroup = new FormGroup({});

  constructor(
    private http: HttpClient,
    private accountService: AccountService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    // this.http.get(this.baseUrl + 'weatherforecast').subscribe({
    //   next: (response) => (this.users = response),
    //   error: (error) => console.log(error),
    //   complete: () => console.log('done'),
    // });

    this.initializeForm();

    this.accountService.login(this.loginForm.value).subscribe({
      next: () => {
        console.log('login success');
      },
    });
  }

  initializeForm() {
    this.loginForm = this.fb.group({
      username: ['bobby', Validators.required],
      password: ['Pass', Validators.required],
    });
  }
}
