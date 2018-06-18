import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';


@Component({
  selector: 'app-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.css']
})
export class PageHeaderComponent implements OnInit {
  isUserLog: Boolean;
  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit() {
    let user = localStorage.getItem('currentUser');
    if(user == null){
      this.isUserLog = false;
    }else{
      this.isUserLog = true;
    }
    console.log(this.isUserLog);
  }

  logout(){
    this.authenticationService.logout();
    location.reload();
  }

}
