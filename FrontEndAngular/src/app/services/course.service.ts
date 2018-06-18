import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { Course } from '../courses/models/course';
import { AppConfig } from '../app.config';

@Injectable()
export class CourseService {

  constructor(private http: Http, private config: AppConfig) { }

  getCourses()  {
    return this.http.get(this.config.apiUrl + '/api/course/courses').map(res => res.json());
  }

  getCourse() : Observable<Course> {
    return this.http.get(this.config.apiUrl + '/api/course/courses'+'/${id}')
          .map(res => res.json());
  }

  getCourseOfUser(idUser : Number) { 
    return this.http.get(this.config.apiUrl + '/api/Course/UserCourses/'+idUser).map(res => res.json());
  }

  getSearchedCourses(searchString : String) {
    return this.http.get(this.config.apiUrl + '/api/Course/SearchCourses/'+searchString).map(res => res.json());
  }

  create(course : any) {
    console.log(course);
    return this.http.post(this.config.apiUrl + '/api/Course/AddCourse', course);
  }

  signUp(idUser,idCourse) {
    return this.http.post(this.config.apiUrl + '/api/Access/gainAccessToCourse', {idUser: idUser, idCourse: idCourse});
  }

  }

  


