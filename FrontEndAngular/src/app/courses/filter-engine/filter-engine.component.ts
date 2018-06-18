import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Course } from '../models/course';
import { CourseService } from '../../services/course.service';
import { CategoryService } from '../../services/category.service';

@Component({
  selector: 'app-filter-engine',
  templateUrl: './filter-engine.component.html',
  styleUrls: ['./filter-engine.component.css']
})
export class FilterEngineComponent implements OnInit {
  courses: Course[];
  categories : any;
  query : any = {};
  idCategory : any;
  constructor(private courseService: CourseService, private categoryService: CategoryService) { }

  @Output() coursesEvent = new EventEmitter<Course[]>();

  ngOnInit() {
    this.categoryService.getCategories().subscribe(categories => {
      this.categories = categories;
    });
  }

  loadSearchedCourse() {
    this.courseService.getSearchedCourses(this.query.text).subscribe(courses => {
      this.courses = <Course[]> courses;
      this.sendCourses();
    });
  }

  sendCourses() {
    this.coursesEvent.emit(this.courses);
  }

}
