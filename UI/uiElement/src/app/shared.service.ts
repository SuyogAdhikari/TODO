import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class SharedService {

  readonly baseApi = "http://localhost:52232/api/"
  constructor(private http: HttpClient) { }

  getTasks(){
    return this.http.get(this.baseApi + 'taskshead'); 
  }

  // uid, taskname, isCompleted
  postTask(taskData){
    console.log(taskData);
    return this.http.post(this.baseApi + 'taskshead', taskData)
  }

  deleteTask(taskId){
    console.log("On services");
    //console.log(taskId);
    return this.http.delete(this.baseApi+'taskshead/'+ taskId)
  }
}
