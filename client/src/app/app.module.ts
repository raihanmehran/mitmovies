import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TextAreaComponent } from './_forms/text-area/text-area.component';
import { SharedModule } from './_modules/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { DatePickerComponent } from './_forms/date-picker/date-picker.component';
import { NavComponent } from './components/base/nav/nav.component';
import { LoginComponent } from './components/base/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './components/base/home/home/home.component';
import { HeaderHomeComponent } from './components/base/home/header-home/header-home.component';
import { FooterHomeComponent } from './components/base/home/footer-home/footer-home.component';
import { CarouselHomeComponent } from './components/base/home/carousel-home/carousel-home.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';

@NgModule({
  declarations: [
    AppComponent,
    TextAreaComponent,
    TextInputComponent,
    DatePickerComponent,
    NavComponent,
    LoginComponent,
    HomeComponent,
    HeaderHomeComponent,
    FooterHomeComponent,
    CarouselHomeComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    CarouselModule.forRoot(),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
