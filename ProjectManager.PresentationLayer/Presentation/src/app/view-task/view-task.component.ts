import { Component, OnInit } from '@angular/core';
import { AddTaskModel } from '../models/add-task.model';
import { ProjectListDialog } from '../add-task/add-task.component';
import { AddProjectModel } from '../models/add-project.model';
import { ApiService } from '../api.service';
import { MatDialog } from '@angular/material';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-task',
  templateUrl: './view-task.component.html',
  styleUrls: ['./view-task.component.css']
})
export class ViewTaskComponent implements OnInit {
  addTaskModel :AddTaskModel;
  taskModel:AddTaskModel[];
  dialogRef: any;
  searchText:any;
  constructor(private apiService: ApiService, public dialog: MatDialog,private router: Router) { 
 this.addTaskModel=new AddTaskModel();
 
  }

  ngOnInit() {
    this.getTasks("");
  }
  public getTasks(sortingParameter:string){
    this.apiService.getTasks(sortingParameter).subscribe((data:AddTaskModel[])=>{
      this.taskModel = data;
      console.log(data);
    })
  }

  public endTask(task :AddTaskModel){
    this.apiService.endTask(task).subscribe((data:boolean)=>{
      this.getTasks("");
      console.log(data);
    })
  }

editTask(task :AddTaskModel){
  debugger;
  this.router.navigate(['/AddTask', { task: JSON.stringify(task) }],{skipLocationChange: true});
}

  openDialog() {

    this.apiService.getProjects().subscribe((data: AddProjectModel[]) => {
      debugger;
      this.dialogRef = this.dialog.open(ProjectListDialog, {
        data: data,
        height: '400px',
        width: '600px'
      });
      this.dialogRef.afterClosed().subscribe(result => {
        debugger;
        console.log(`Dialog result: ${result}`);
        this.addTaskModel.Project_ID = result;
      });
    })
  }
}