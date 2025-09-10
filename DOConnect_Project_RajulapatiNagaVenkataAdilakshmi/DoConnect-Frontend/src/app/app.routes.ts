import { Routes } from '@angular/router';

// landing
import { LandingComponent } from './landing/landing';

// Auth
import { LoginComponent } from './auth/login/login';
import { RegisterComponent } from './auth/register/register';

// User
import { HomeComponent } from './user/home/home';
import { AskQuestionComponent } from './user/ask-question/ask-question';
import { MyQuestionsComponent } from './user/my-questions/my-questions';
import { MyAnswersComponent } from './user/my-answers/my-answers';
import { ProfileComponent } from './user/profile/profile';
import { GiveAnswerComponent } from './user/give-answer/give-answer';

// Admin
import { DashboardComponent } from './admin/dashboard/dashboard';
import { ManageQuestionsComponent } from './admin/manage-questions/manage-questions';
import { ManageAnswersComponent } from './admin/manage-answers/manage-answers';
import { ManageUsersComponent } from './admin/manage-users/manage-users';

// Guards
import { AuthGuard } from './guards/auth-guard';
import { AdminGuard } from './guards/admin-guard';
import { LoggedInGuard } from './guards/logged-in-guard';
import { ResetPasswordComponent } from './user/reset-password/reset-password';
import { ForgotPasswordComponent } from './user/forgot-password/forgot-password';

export const routes: Routes = [
  { path: '', component: LandingComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent, canActivate: [LoggedInGuard]},
  { path: 'register', component: RegisterComponent, canActivate: [LoggedInGuard] },
  { path: 'forgot-password', component: ForgotPasswordComponent },
  { path: 'reset-password', component: ResetPasswordComponent },
  
  // User
    { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'ask-question', component: AskQuestionComponent, canActivate: [AuthGuard] },
  { path: 'my-questions', component: MyQuestionsComponent, canActivate: [AuthGuard] },
  { path: 'my-answers', component: MyAnswersComponent, canActivate: [AuthGuard] },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
  { path: 'give-answer', component: GiveAnswerComponent, canActivate: [AuthGuard] },
  { path: 'give-answer/:id', component: GiveAnswerComponent, canActivate: [AuthGuard] },

  // Admin
  { path: 'admin/dashboard', component: DashboardComponent, canActivate: [AdminGuard] },
  { path: 'admin/manage-questions', component: ManageQuestionsComponent, canActivate: [AdminGuard] },
  { path: 'admin/manage-answers', component: ManageAnswersComponent, canActivate: [AdminGuard] },
  { path: 'admin/manage-users', component: ManageUsersComponent, canActivate: [AdminGuard] },

  { path: '**', redirectTo: '', pathMatch: 'full'}
];
