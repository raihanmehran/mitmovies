import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { AppComponent } from '../app.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDatepickerModule.forRoot(),
    FontAwesomeModule,
    ToastrModule.forRoot(),
  ],
  exports: [BsDatepickerModule, FontAwesomeModule, ToastrModule],
  bootstrap: [AppComponent],
})
export class SharedModule {}
