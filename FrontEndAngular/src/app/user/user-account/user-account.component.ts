import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-account',
  templateUrl: './user-account.component.html',
  styleUrls: ['./user-account.component.css']
})
export class UserAccountComponent implements OnInit {
  dataVisible = false;

  constructor(private router : Router) { }

  showData(): void {
    this.dataVisible = true;
  }

  routeToUserCourseList(): void {
    this.router.navigate(['/user-course-list']);
  }

  ngOnInit() {
  }

}
