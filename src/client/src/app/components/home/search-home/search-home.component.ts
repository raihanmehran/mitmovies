import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-search-home',
  templateUrl: './search-home.component.html',
  styleUrls: ['./search-home.component.css'],
})
export class SearchHomeComponent implements OnInit {
  searchForm: FormGroup = new FormGroup({});

  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.searchForm = this.fb.group({
      searchValue: [
        '',
        [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(200),
        ],
      ],
    });
  }

  search() {
    if (this.searchForm.valid)
      this.router.navigateByUrl(
        'search/' + this.searchForm.controls['searchValue'].value
      );
    else if (this.searchForm.invalid) this.toastr.warning('Invalid');
  }
}
