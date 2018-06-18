import { NgModule } from '@angular/core';
import { RouterModule, RouterOutlet, Route } from '@angular/router';
import { CarouselSliderComponent } from '../app/layout/carousel-slider/carousel-slider.component';
import { FeatureBoxComponent } from './layout/feature-box/feature-box.component';
import { FooterComponent } from './layout/footer/footer.component';
import { UserAccountComponent } from './user/user-account/user-account.component';
import { AuthGuard } from './guards/auth.guard';
import { UserCourseListComponent } from './courses/user-course-list/user-course-list.component';
import { VideoPlayerComponent } from './courses/video-player/video-player.component';

const APP_ROUTERS: Route[] = [
    {
        path: '', component: CarouselSliderComponent,
        children: [
            { path: '', component: FeatureBoxComponent, outlet: 'featureBoxChild' },
            { path: '', component: FooterComponent, outlet: 'footerChild' }
        ]
    },
    {
        path: 'user-account', component: UserAccountComponent, canActivate: [AuthGuard]
    },
    {
        path: 'user-course-list', component: <any>UserCourseListComponent, canActivate: [AuthGuard]
    },
    {
        path: 'app-video-player', component: <any>VideoPlayerComponent
    }
];

@NgModule({
    imports: [
        RouterModule.forRoot(APP_ROUTERS)
    ],

    exports: [
        RouterModule
    ]
})

export class AppRouterModule {}
