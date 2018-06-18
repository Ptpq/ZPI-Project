import { Observable } from 'rxjs/Observable';
import { CourseService } from './../../services/course.service';
import { Component, OnInit } from '@angular/core';
import { Course } from '../models/course';
import { AuthenticationService } from '../../services/authentication.service';
import { FilterEngineComponent } from './../filter-engine/filter-engine.component';
import { AlertService } from '../../services/alert.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css'],
  providers: [CourseService]
})
export class CourseListComponent implements OnInit {
  isUserLog: Boolean;
  courses: Course[];
  loading = false;

  constructor(
    private courseService: CourseService, 
    private authenticationService: AuthenticationService,
    private alertService: AlertService,
    private router: Router) {}


  ngOnInit() {
    let user = localStorage.getItem('currentUser');
    if(user == null){
      this.isUserLog = false;
    }else{
      this.isUserLog = true;
    }
    console.log(this.isUserLog);
    this.loadCourse();
  }

  loadCourse() {
    this.courseService.getCourses().subscribe(courses => {
      this.courses = <Course[]>courses;
      console.log('Courses', this.courses);
    });
  }

  receiveSearchedCourses($event) {
    this.courses = $event;
    console.log(this.courses + "z listy kursow");
  }

  signUpForCourse(idCourse) {
    this.loading = true;
    let user = JSON.parse(localStorage.getItem('currentUser'));
    this.courseService.signUp(user.id,idCourse).subscribe(
      data => {
        this.alertService.success('Creation successful', true);
        this.router.navigate(['/user-course-list']);
      },
      error => {
          this.alertService.error(error._body);
          this.loading = false;
      });;
  }
  



}
