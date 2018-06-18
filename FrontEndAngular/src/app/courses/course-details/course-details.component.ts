import { Component, OnInit } from '@angular/core';
import { CourseService } from '../../services/course.service';
import { ActivatedRoute } from '@angular/router';
import { Course } from '../models/course';
import { Video } from '../models/video';
import { VideoService } from '../../services/video.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.css'],
  providers: [VideoService]
})
export class CourseDetailsComponent implements OnInit {
  videos: any;
  idCourse : any;

  constructor(private videoService: VideoService, 
    private router : Router,
    private route: ActivatedRoute) {}

  ngOnInit() {
    this.idCourse = this.route.snapshot.url[0].path;
    this.loadVideo();
  }

  loadVideo() {
   

    this.videoService.getVideos(this.idCourse).subscribe(videos => {
      this.videos = videos;
  });
  }

  routeToVideoPlayer(idVideo) : void {
    console.log(idVideo);
    localStorage.setItem("idVideo", idVideo);
    this.router.navigate(['/app-video-player/']);
  }
}
