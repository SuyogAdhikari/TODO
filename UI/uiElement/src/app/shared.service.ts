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

  postTasks(){
    
  }

  putTasks(){

  }

  deleteTasks(){

  }

}
