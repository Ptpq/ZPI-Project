import { Observable } from 'rxjs/Observable';
import { CourseService } from './../../services/course.service';
import { Component, OnInit } from '@angular/core';
import { Course } from '../models/course';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-user-course-list',
  templateUrl: './user-course-list.component.html',
  styleUrls: ['./user-course-list.component.css'],
  providers: [CourseService]
})
export class UserCourseListComponent implements OnInit {

  courses: Course[];

  constructor(private courseService: CourseService) {}


  ngOnInit() {
    let user = JSON.parse(localStorage.getItem("currentUser"));
    console.log(user);
    this.courseService.getCourseOfUser(user.id).subscribe(courses => {
      this.courses = <Course[]>courses;
    });
  }



}
