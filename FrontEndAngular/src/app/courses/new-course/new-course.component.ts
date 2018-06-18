import { Course } from './../models/course';
import { CategoryService } from './../../services/category.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { AlertService } from '../../services/alert.service';
import { CourseService } from '../../services/course.service';

@Component({
  selector: 'app-new-course',
  templateUrl: './new-course.component.html',
  styleUrls: ['./new-course.component.css']
})
export class NewCourseComponent implements OnInit  {
  //model: Course =  {idCourse: 0, title: "", description: "", idCategory: 0, category: null};
  model: any = {};
  categories : any;
  loading = false;
  selectedCategory : any;

  ngOnInit() {
    this.categoryService.getCategories().subscribe(categories => {
      this.categories = categories;
      this.selectedCategory = this.categories[0];
    });
  }

  constructor(
    private router: Router,
        private courseService: CourseService,
        private categoryService: CategoryService,
        private alertService: AlertService) { }

  createCourse() {
    this.loading = true;
    this.courseService.create(this.model)
        .subscribe(
          data => {
            this.alertService.success('Creation successful', true);
            this.router.navigate(['/courses-list']);
          },
          error => {
              this.alertService.error(error._body);
              this.loading = false;
          });
  }

  showModel() {
    console.log(this.model);
  }


}
