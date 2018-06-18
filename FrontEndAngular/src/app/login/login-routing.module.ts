import { RouterModule, Route } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { RegistrationComponent } from './registration/registration.component';

const LOGIN_ROUTES: Route[] = [
    {
        path: 'login', component: <any>LoginComponent
    },
    {
        path: 'registration', component: <any>RegistrationComponent
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(LOGIN_ROUTES)
    ],
    exports: [
        RouterModule
    ]
})

export class LoginRoutingModule {}
