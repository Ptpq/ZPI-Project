import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable';
import { Course } from '../courses/models/course';
import { AppConfig } from '../app.config';

@Injectable()
export class CategoryService {

  constructor(private http: Http, private config: AppConfig) { }

  getCategories()  {
    return this.http.get(this.config.apiUrl + '/api/category/categories').map(res => res.json());
  }

}