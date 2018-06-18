import { RouterModule, Route } from '@angular/router';
import { NgModule } from '@angular/core';
import { UserAccountComponent } from './user-account/user-account.component';
import { AuthGuard } from '../guards/auth.guard';

const USER_ROUTES: Route[] = [
    {
        path: 'user-account', component: <any>UserAccountComponent, canActivate: [AuthGuard]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(USER_ROUTES)
    ],
    exports: [
        RouterModule
    ]
})

export class UserAccountRoutingModule {}
