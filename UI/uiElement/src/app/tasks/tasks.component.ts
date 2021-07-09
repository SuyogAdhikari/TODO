import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {
  taskshead : Object;
  constructor(private _http : SharedService) { }

  ngOnInit() {
    this._http.getTasks().subscribe(data => {
      this.taskshead = data;
      console.log(this.taskshead);
    })
  }
}
