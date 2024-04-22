import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable()
export class TaskSchedulerService {
  private baseApiUrl: string = `${environment.backUrl}`;

  constructor(private http: HttpClient) { }

  public TaskScheduler(model: any) {
    const url = `${this.baseApiUrl}TaskScheduler`;
    return this.http.post<any>(url, model);
  }

}
