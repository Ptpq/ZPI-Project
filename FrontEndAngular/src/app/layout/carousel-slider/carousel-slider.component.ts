import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../services/authentication.service';

@Component({
  selector: 'app-carousel-slider',
  templateUrl: './carousel-slider.component.html',
  styleUrls: ['./carousel-slider.component.css']
})
export class CarouselSliderComponent implements OnInit {
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

  

}
