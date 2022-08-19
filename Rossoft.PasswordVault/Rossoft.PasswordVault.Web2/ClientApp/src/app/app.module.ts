import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NoopAnimationsModule } from '@angular/platform-browser/animations'
import { MaterialModule } from './material-module'

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CompaniesComponent } from './company/companies.component';
import { VeiwCompanyComponent } from './company/veiw-company.component';
import { AddEditContactComponent } from './contact/add-edit-contact.component'
import { AddEditServerComponent } from './server/add-edit-server.component';
import { SearchComponent } from './search/search.component';
import { AddEditCompanyComponent } from './company/add-edit-company.component';
import { OverwritePrimaryDialogComponent } from './contact/overwrite-primary-dialog';
import { DeleteDialogComponent } from './company/delete-dialog.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CompaniesComponent,
    AddEditCompanyComponent,
    VeiwCompanyComponent,
    AddEditContactComponent,
    AddEditServerComponent,
    SearchComponent,
    OverwritePrimaryDialogComponent,
    DeleteDialogComponent,

  ],
  imports: [
    MaterialModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ApiAuthorizationModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full'},
      { path: 'add-edit-company', component: AddEditCompanyComponent},
      { path: 'add-edit-company/:id', component: AddEditCompanyComponent},
      { path: 'veiw-company/:id', component: VeiwCompanyComponent},
      { path: 'add-edit-contact/:companyid/:id', component: AddEditContactComponent},
      { path: 'add-edit-contact/:companyid', component: AddEditContactComponent},
      { path: 'add-edit-server/:companyid/:id', component: AddEditServerComponent},
      { path: 'add-edit-server/:companyid', component: AddEditServerComponent},
      { path: 'search/:searchphrase', component: SearchComponent},
    ]),
    NoopAnimationsModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
