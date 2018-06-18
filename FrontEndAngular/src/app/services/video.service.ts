import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Video } from '../courses/models/video';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class VideoService {

  constructor(private http: Http) { }

  getVideo(id: number)  {
    return this.http.get('http://localhost:54674/api/videolist/Video/'+id).map(res => res.json());
  }

  getVideos(id: number) {
    return this.http.get('http://localhost:54674/api/videolist/'+id).map(res => res.json());
  }

}
