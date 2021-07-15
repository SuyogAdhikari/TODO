import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  taskhead : Object; 
  constructor(private _http : SharedService) { }

  ngOnInit() {    
    this.viewTasks();
  }

  viewTasks(){
    this._http.getTasks().subscribe(data => {
     console.log(data);
      this.taskhead = data;
      // console.log(this.taskshead);
    })
  }

  addTask(taskhead){
    console.log(taskhead);
    this._http.postTask(taskhead).subscribe(data =>{
      this.viewTasks();
      console.log("TaskHead from TaskComponent : " + taskhead);      
    });
  }  

  removeTask(taskhead){
    console.log(taskhead);
    this._http.deleteTask(taskhead.tasksNameId).subscribe(data=>{
      this.viewTasks();
    })
  }
}
