import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { AdminModule } from './admin/admin.module';
import { BaseService } from './services/base.service';
import { RentService } from './services/rent.service';
import { SkiService } from './services/ski.service';
import { HttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

const appRoutes: Routes = [
  { path: '', loadChildren: './admin/admin.module#AdminModule' }
];

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    FormsModule,
    HttpClientModule,
    BrowserModule,
    AdminModule,
    RouterModule.forRoot(appRoutes, { enableTracing: true })
  ],
  providers: [
    BaseService,
    RentService,
    SkiService,
    HttpClient
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
