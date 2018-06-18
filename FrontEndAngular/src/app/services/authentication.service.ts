import { AppConfig } from './../app.config';
import { Http, Headers, Response } from '@angular/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';


@Injectable()
export class AuthenticationService {

  constructor(private http: Http, private config: AppConfig) { }

  login(login: string, password: string) {
    return this.http.post(this.config.apiUrl + '/api/user/authenticate', {login: login, password: password})
    .map( (response: Response) => {
      // login successful if there;s a jwt token in the response
      const user = response.json();
      if (user && user.token) {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem('currentUser', JSON.stringify(user));
      }
    });
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
  }

}
