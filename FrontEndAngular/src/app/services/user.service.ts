import { User } from './../login/user';
import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { AppConfig } from '../app.config';


@Injectable()
export class UserService {

  constructor(private http: Http, private config: AppConfig) { }

  create(user: User) {
    return this.http.post(this.config.apiUrl + '/api/user/register', user, this.jwt());
  }

  private jwt() {
    // create authorization header with jwt token
    const currentUser = JSON.parse(localStorage.getItem('currentUser'));
    if (currentUser && currentUser.token) {
      const headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.token});
      return new RequestOptions({ headers: headers});
    }
  }

}
