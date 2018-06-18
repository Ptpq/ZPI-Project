import { RouterModule, Route } from '@angular/router';
import { NgModule } from '@angular/core';
import { CourseListComponent } from './course-list/course-list.component';
import { UserCourseListComponent } from './user-course-list/user-course-list.component';
import { NewCourseComponent } from './new-course/new-course.component';
import { CourseDetailsComponent } from './course-details/course-details.component';
import { VideoPlayerComponent } from './video-player/video-player.component';
import { AuthGuard } from '../guards/auth.guard';

const COURSES_ROUTES: Route[] = [
    {
        path: 'courses-list', component: <any>CourseListComponent
    },
    {
        path: 'user-course-list', component: <any>UserCourseListComponent, canActivate: [AuthGuard]
    },
    {
        path: 'new-courses', component: <any>NewCourseComponent, canActivate: [AuthGuard]
    },
    {
        path: ':idCourse', component: <any>CourseDetailsComponent
    },
    {
        path: ':idVideo', component: <any>VideoPlayerComponent
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(COURSES_ROUTES)
    ],
    exports: [
        RouterModule
    ]
})

export class CoursesRoutingModule {}
