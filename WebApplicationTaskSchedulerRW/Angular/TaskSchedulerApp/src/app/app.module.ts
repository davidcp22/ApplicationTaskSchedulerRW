import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { TaskScheluderComponentComponent } from './Components/task-scheluder-component/task-scheluder-component.component';
import { TaskSchedulerService } from './core/services/task-scheluder.service';

@NgModule({
  declarations: [
    AppComponent,
    TaskScheluderComponentComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [
    TaskSchedulerService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
