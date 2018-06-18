import { Component, OnInit } from '@angular/core';
import { VideoService } from '../../services/video.service';
import { Router, ActivatedRoute } from '@angular/router';
 
@Component({
  selector: 'app-video-player',
  templateUrl: './video-player.component.html',
  styleUrls: ['./video-player.component.css'],
  providers: [VideoService]
})
export class VideoPlayerComponent implements OnInit {
  video: any;
  id : any;
 
  constructor(private videoService: VideoService,
    private router : Router,
    private route: ActivatedRoute) {}
    
 
    ngOnInit() {
      this.id =  localStorage.getItem("idVideo");
      this.loadVideo();
    }
 
    loadVideo() {
        this.videoService.getVideo(this.id).subscribe(video => {
        this.video = video;
        console.log(video.directory);
    });
    }
 
}