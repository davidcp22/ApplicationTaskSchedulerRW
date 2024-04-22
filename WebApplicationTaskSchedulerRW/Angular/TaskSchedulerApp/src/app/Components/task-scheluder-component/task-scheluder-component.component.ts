import { Component, OnInit } from '@angular/core';
import { TaskSchedulerService } from 'src/app/core/services/task-scheluder.service';

@Component({
  selector: 'app-task-scheluder-component',
  templateUrl: './task-scheluder-component.component.html',
  styles: [
  ]
})
export class TaskScheluderComponentComponent implements OnInit {
  model: { url: string, cronExpression: string } = { url: '', cronExpression: '' };
  constructor(private taskSchedulerService: TaskSchedulerService ) { }

  ngOnInit(): void {
  }
  submitForm(form: any) {
    if (form.valid) {
      const url = form.value.url;
      const cronExpression = form.value.cronExpression;

      this.model = { url: url, cronExpression: cronExpression };
      try {
        const response = this.taskSchedulerService.TaskScheduler(this.model).toPromise();
        console.log(response);

      } catch (error) {
        console.log(error)
      }

      form.resetForm();
    }
  }
}
