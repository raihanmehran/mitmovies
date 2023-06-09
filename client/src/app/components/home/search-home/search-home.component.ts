import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-search-home',
  templateUrl: './search-home.component.html',
  styleUrls: ['./search-home.component.css'],
})
export class SearchHomeComponent implements OnInit {
  searchForm: FormGroup = new FormGroup({});

  constructor(private fb: FormBuilder, private toastr: ToastrService) {}
  ngOnInit(): void {
    this.initializeForm();
  }

  writeValue(obj: any): void {}
  registerOnChange(fn: any): void {}
  registerOnTouched(fn: any): void {}

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
    if (this.searchForm.invalid) this.toastr.warning('Invalid');
    else
      this.toastr.success(
        'Clicked : value = ' + this.searchForm.controls['searchValue'].value
      );
  }
}
