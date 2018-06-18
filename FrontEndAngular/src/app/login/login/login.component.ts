import { PageHeaderComponent } from './../../layout/page-header/page-header.component';
import { AlertService } from './../../services/alert.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  model: any = {};
  loading = false;
  returnUrl: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private alertService: AlertService) {}

  ngOnInit() {
    // reset login status
    this.authenticationService.logout();

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  singIn() {
    this.loading = true;
    this.authenticationService.login(this.model.login, this.model.password)
      .subscribe( data => {
        //this.router.navigate([this.returnUrl]);
        window.location.pathname = this.returnUrl;
      },
      error => {
        this.alertService.error(error._body);
        this.loading = false;
      });
  }

}
