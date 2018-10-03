import { Component, OnInit, Inject } from '@angular/core';
import { AddTaskModel } from '../models/add-task.model';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { MatDialogRef, MatTableDataSource } from "@angular/material";
import { ApiService } from '../api.service';
import { AddProjectModel } from '../models/add-project.model';
import { AddUserModel } from '../models/add-user.model';
import { ManagerUserListDialog } from '../add-project/add-project.component';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css']
})
export class AddTaskComponent implements OnInit {


  addTaskModel: AddTaskModel;
  TaskModel: AddTaskModel[];
  TaskListCount: number;
  isUpdate: boolean;
  isParentTask: boolean;
  managerData: string;
  tmpDate: Date;
  dialogRef: any;
  searchText: string;
  pageHeader: string;

  constructor(private apiService: ApiService, public dialog: MatDialog, route: ActivatedRoute,private location: Location) {
    this.addTaskModel = new AddTaskModel();
    debugger;
    if (route.snapshot.params['task'])
      this.addTaskModel = JSON.parse(route.snapshot.params['task']);
    if (this.addTaskModel.Task_ID || this.addTaskModel.Parent_ID) {
      this.pageHeader = "Update Task";
      this.isUpdate=true;
    }
    else {
      this.pageHeader = "Add Task";
      this.isUpdate=false;
      this.addTaskModel.isParentTask = false;
      this.addTaskModel.Start_Date = new Date();
      var tmp = new Date();
      tmp.setDate(tmp.getDate() + 1);
      this.addTaskModel.End_Date = tmp;
    }
  }

  ngOnInit() {
  }

  public toggleTask() {
    if (this.addTaskModel.isParentTask) {
      this.addTaskModel.Start_Date = null;
      this.addTaskModel.End_Date = null;
      this.addTaskModel.Priority = null;
      this.addTaskModel.Parent_ID = null;
    }
    else {
      this.addTaskModel.Start_Date = new Date();
      var tmp = new Date();
      tmp.setDate(tmp.getDate() + 1);
      this.addTaskModel.End_Date = tmp;
    }
  }

  onSubmit() {
    this.apiService.addTask(this.addTaskModel).subscribe((data: boolean) => {
      console.log("component :" + data);
      this.addTaskModel.Project_ID = null;
      this.addTaskModel.User_ID = null;
      this.isUpdate = false;
      this.addTaskModel.isParentTask = false;
      this.addTaskModel.Start_Date = new Date();
      var tmp = new Date();
      tmp.setDate(tmp.getDate() + 1);
      this.addTaskModel.End_Date = tmp;
      this.pageHeader = "Add Task";
    })
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

  openUsersDialog() {

    this.apiService.getUsers("").subscribe((data: AddUserModel[]) => {
      debugger;
      this.dialogRef = this.dialog.open(ManagerUserListDialog, {
        data: data
      });
      this.dialogRef.afterClosed().subscribe(result => {
        debugger;
        console.log(`Dialog result: ${result}`);
        this.addTaskModel.User_ID = result;
      });
    })
  }

  openParentTaskDialog() {

    this.apiService.getParentTasks().subscribe((data: AddTaskModel[]) => {
      this.dialogRef = this.dialog.open(ManagerTaskListDialog, {
        data: data
      });
      this.dialogRef.afterClosed().subscribe(result => {

        console.log(`Dialog result: ${result}`);
        this.addTaskModel.Parent_ID = result;
      });
    })
  }

}

@Component({
  selector: 'project-list',
  templateUrl: 'projectList.html',
})
export class ProjectListDialog {
  constructor(@Inject(MAT_DIALOG_DATA) public data: AddProjectModel[], private dialogRef: MatDialogRef<ProjectListDialog>) {
    //     this.data.forEach(data => {
    // data
    //     });
  }
  selectedUser: any;

  displayedColumns: string[] = ['Project_ID', 'Project', 'Start_Date', 'End_Time', 'Priority'];

  dataSource = new MatTableDataSource(this.data);

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  public onSave(element) {
    this.dialogRef.close(element.Project_ID);
  }
}


@Component({
  selector: 'manager-task-list',
  templateUrl: 'parentTaskList.html',
})
export class ManagerTaskListDialog {
  constructor(@Inject(MAT_DIALOG_DATA) public data: AddTaskModel[], private dialogRef: MatDialogRef<ManagerTaskListDialog>) {
    //     this.data.forEach(data => {
    // data
    //     });
  }
  selectedUser: any;

  displayedColumns: string[] = ['Parent_ID', 'Task', 'ParentTaskTitle'];

  dataSource = new MatTableDataSource(this.data);

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  public onSave(element) {
    this.dialogRef.close(element.Parent_ID);
  }
}