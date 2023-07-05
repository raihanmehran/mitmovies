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
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FooterHomeComponent } from './components/home/footer-home/footer-home.component';
import { HeaderHomeComponent } from './components/home/header-home/header-home.component';
import { ProfileUserComponent } from './components/member/profile-user/profile-user.component';
import { CardLongComponent } from './_forms/card-long/card-long.component';
import { MovieCardShortComponent } from './_forms/movie-card-short/movie-card-short.component';
import { EditUserComponent } from './components/user/edit-user/edit-user.component';
import { PopularMoviesComponent } from './components/movies/popular-movies/popular-movies.component';
import { TrendingMoviesComponent } from './components/home/trending-movies/trending-movies.component';
import { CommonModule } from '@angular/common';
import { HomePopularMoviesComponent } from './components/home/home-popular-movies/home-popular-movies.component';
import { MovieDetailComponent } from './components/movies/movie-detail/movie-detail/movie-detail.component';
import { YouTubePlayerModule } from '@angular/youtube-player';
import { TrendingTvShowsComponent } from './components/home/trending-tv-shows/trending-tv-shows.component';
import { TvCardShortComponent } from './_forms/tv-card-short/tv-card-short.component';
import { TvDetailComponent } from './components/tv/tv-detail/tv-detail/tv-detail.component';
import { MediaDetailComponent } from './_forms/media-detail/media-detail.component';
import { ReviewsDetailComponent } from './_forms/reviews-detail/reviews-detail.component';
import { RecommendationsDetailComponent } from './_forms/recommendations-detail/recommendations-detail.component';
import { CastDetailComponent } from './_forms/cast-detail/cast-detail.component';
import { SeasonsTvDetailComponent } from './components/tv/tv-detail/seasons-tv-detail/seasons-tv-detail.component';
import { SearchHomeComponent } from './components/home/search-home/search-home.component';
import { SearchResultComponent } from './components/search/search-result/search-result.component';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { RatingModule } from 'ngx-bootstrap/rating';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { UpcomingMoviesComponent } from './components/movies/upcoming-movies/upcoming-movies.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { TopratedMoviesComponent } from './components/movies/toprated-movies/toprated-movies.component';
import { PopularTvComponent } from './components/tv/popular-tv/popular-tv.component';

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
    TrendingTvShowsComponent,
    TvCardShortComponent,
    TvDetailComponent,
    MediaDetailComponent,
    ReviewsDetailComponent,
    RecommendationsDetailComponent,
    CastDetailComponent,
    SeasonsTvDetailComponent,
    SearchHomeComponent,
    SearchResultComponent,
    UpcomingMoviesComponent,
    TopratedMoviesComponent,
    PopularTvComponent,
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
    TooltipModule.forRoot(),
    RatingModule.forRoot(),
    CarouselModule.forRoot(),
    PaginationModule.forRoot(),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
