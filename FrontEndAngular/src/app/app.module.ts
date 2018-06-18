import { CategoryService } from './services/category.service';
import { LoginComponent } from './login/login/login.component';
import { UserService } from './services/user.service';
import { AuthGuard } from './guards/auth.guard';
import { AppConfig } from './app.config';
import { AuthenticationService } from './services/authentication.service';
import { AlertService } from './services/alert.service';
import { CourseService } from './services/course.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CarouselModule, SlideComponent } from 'ngx-bootstrap/carousel';
import { AppComponent } from './app.component';
import { PageHeaderComponent } from './layout/page-header/page-header.component';
import { FeatureBoxComponent } from './layout/feature-box/feature-box.component';
import { FooterComponent } from './layout/footer/footer.component';
import { CarouselSliderComponent } from './layout/carousel-slider/carousel-slider.component';
import { AppRouterModule } from './app-routing.module';
import { LoginRoutingModule } from './login/login-routing.module';
import { LoginModule } from './login/login.module';
import { CoursesModule } from './courses/courses.module';
import { FilterEngineComponent } from './courses/filter-engine/filter-engine.component';
import { CoursesRoutingModule } from './courses/courses-routing.module';
import { UserAccountRoutingModule } from './user/user-routing.module';
import { UserModule } from './user/user.module';
import { HttpModule } from '@angular/http';
import { AlertComponent } from './alert/alert.component';
import { RegistrationComponent } from './login/registration/registration.component';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    PageHeaderComponent,
    CarouselSliderComponent,
    FeatureBoxComponent,
    FooterComponent,
    AlertComponent
  ],
  imports: [
    CarouselModule.forRoot(),
    LoginModule,
    FormsModule,
    BrowserModule,
    AppRouterModule,
    LoginRoutingModule,
    CoursesModule,
    CoursesRoutingModule,
    UserModule,
    UserAccountRoutingModule,
    HttpModule,
    ReactiveFormsModule 
  ],
  providers: [CourseService, AlertService, AuthenticationService, AppConfig, AuthGuard, UserService, CategoryService],
  bootstrap: [AppComponent]
})
export class AppModule { }
