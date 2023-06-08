import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './_modules/shared.module';
import { DatePickerComponent } from './_forms/date-picker/date-picker.component';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { TextAreaComponent } from './_forms/text-area/text-area.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthComponent } from './components/user/auth/auth.component';
import { NavComponent } from './components/home/nav/nav.component';
import { HomeComponent } from './components/home/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { FooterHomeComponent } from './components/home/footer-home/footer-home.component';
import { HeaderHomeComponent } from './components/home/header-home/header-home.component';
import { ProfileUserComponent } from './components/user/profile-user/profile-user.component';
import { CardLongComponent } from './_forms/card-long/card-long.component';
import { MovieCardShortComponent } from './_forms/movie-card-short/movie-card-short.component';
import { EditUserComponent } from './components/user/edit-user/edit-user.component';
import { PopularMoviesComponent } from './components/movies/popular-movies/popular-movies.component';
import { TrendingMoviesComponent } from './components/home/trending-movies/trending-movies.component';
import { CommonModule } from '@angular/common';
import { HomePopularMoviesComponent } from './components/home/home-popular-movies/home-popular-movies.component';
import { MovieDetailComponent } from './components/movies/movie-detail/movie-detail/movie-detail.component';
import { YouTubePlayerModule } from '@angular/youtube-player';
import { CastMovieDetailComponent } from './components/movies/movie-detail/cast-movie-detail/cast-movie-detail.component';
import { TrendingTvShowsComponent } from './components/home/trending-tv-shows/trending-tv-shows.component';
import { TvCardShortComponent } from './_forms/tv-card-short/tv-card-short.component';
import { TvDetailComponent } from './components/tv/tv-detail/tv-detail/tv-detail.component';
import { CastTvDetailComponent } from './components/tv/tv-detail/cast-tv-detail/cast-tv-detail.component';
import { MediaDetailComponent } from './_forms/media-detail/media-detail.component';
import { ReviewsDetailComponent } from './_forms/reviews-detail/reviews-detail.component';
import { RecommendationsDetailComponent } from './_forms/recommendations-detail/recommendations-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    DatePickerComponent,
    TextInputComponent,
    TextAreaComponent,
    AuthComponent,
    NavComponent,
    HomeComponent,
    FooterHomeComponent,
    HeaderHomeComponent,
    ProfileUserComponent,
    CardLongComponent,
    MovieCardShortComponent,
    EditUserComponent,
    TrendingMoviesComponent,
    PopularMoviesComponent,
    HomePopularMoviesComponent,
    MovieDetailComponent,
    CastMovieDetailComponent,
    TrendingTvShowsComponent,
    TvCardShortComponent,
    TvDetailComponent,
    CastTvDetailComponent,
    MediaDetailComponent,
    ReviewsDetailComponent,
    RecommendationsDetailComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    SharedModule,
    YouTubePlayerModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
