import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseListComponent } from './course-list/course-list.component';
import { FilterEngineComponent } from './filter-engine/filter-engine.component';
import { NewCourseComponent } from './new-course/new-course.component';
import { NewPartComponent } from './new-part/new-part.component';
import { UserCourseListComponent } from './user-course-list/user-course-list.component';
import { CourseDetailsComponent } from './course-details/course-details.component';
import { RouterModule } from '@angular/router';
import { VideoPlayerComponent } from './video-player/video-player.component';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [CourseListComponent],
  declarations: [CourseListComponent, FilterEngineComponent, NewCourseComponent, NewPartComponent, UserCourseListComponent, CourseDetailsComponent, VideoPlayerComponent]
})
export class CoursesModule { }
