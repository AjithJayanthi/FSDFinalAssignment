import { Component, OnInit, Inject } from '@angular/core';
import { AddProjectModel } from '../models/add-project.model';
import { ApiService } from '../api.service';
import {MatButtonModule, MatCheckboxModule,MatDatepicker} from '@angular/material';
import * as moment from 'moment';
import {MatDialog, MAT_DIALOG_DATA} from '@angular/material';
import { MatDialogRef,MatTableDataSource } from "@angular/material";
import { AddUserModel } from '../models/add-user.model';


@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.css']
})
export class AddProjectComponent implements OnInit {

  addProjectModel: AddProjectModel;
  ProjectModel: AddProjectModel[];
  ProjectListCount: number;
  isUpdate: boolean;
  isSetDateEnabled: boolean;
  managerData:string;
  tmpDate:Date;
  dialogRef:any;
  searchText:string;
  constructor(private apiService: ApiService,public dialog: MatDialog) {
    this.addProjectModel = new AddProjectModel();

    this.isUpdate = false;
    this.isSetDateEnabled = false;
  }

  ngOnInit() {

    this.getProjects();
    this.addProjectModel.Priority = 0;
  }

  openDialog() {

      this.apiService.getUsers("").subscribe((data:AddUserModel[])=>{
        debugger;
        this.dialogRef = this.dialog.open(ManagerUserListDialog, {      
          data: data
        });
        this.dialogRef.afterClosed().subscribe(result => {
          debugger;
          console.log(`Dialog result: ${result}`);
          this.addProjectModel.User_ID=result;
      });
      })

   
  }

public toggleSetDate(){
  //this.isSetDateEnabled = this.isSetDateEnabled?false:true;
  if(this.isSetDateEnabled){
    this.addProjectModel.Start_Date = new Date();
     this.tmpDate  = new Date();
     this.tmpDate.setDate(this.tmpDate.getDate()+1);
     this.addProjectModel.End_Time = this.tmpDate;
  }
  else{
    this.addProjectModel.Start_Date = null;
    this.addProjectModel.End_Time = null;
  }
}

public validateDate(event){
if(this.addProjectModel.Start_Date>this.addProjectModel.End_Time){
  console.log("Date wrong");
}
}

  public getProjects(sortParameter?:string) {
    this.apiService.getProjects(sortParameter).subscribe((data: AddProjectModel[]) => {
      debugger;
      this.ProjectModel = data;
      console.log(data);
      this.ProjectListCount = data.length;
    })
  }

  submitted = false;

  onSubmit() {
    this.apiService.addProject(this.addProjectModel).subscribe((data: boolean) => {
      console.log("component :" + data);
      this.getProjects();
      this.addProjectModel.Project_ID = null;
      this.isUpdate = false;
      this.isSetDateEnabled = false;
    })
  }

  editProject(project: AddProjectModel) {
    this.addProjectModel.Project_ID = project.Project_ID;
    this.addProjectModel.Start_Date = project.Start_Date;
    this.addProjectModel.End_Time = project.End_Time;
    this.addProjectModel.Priority = project.Priority;
    this.addProjectModel.Project  = project.Project;
    this.addProjectModel.User_ID = project.User_ID;
    if(project.Start_Date != null){
      this.isSetDateEnabled = true;
    }
    this.isUpdate = true;
  }

  public deleteProject(project: AddProjectModel) {
    this.apiService.deleteProject(project).subscribe((data: boolean) => {
      console.log(data);
      this.getProjects();
    })
  }

}


@Component({
  selector: 'manager-user-list',
  templateUrl: 'managerUserList.html',
})
export class ManagerUserListDialog {
  constructor(@Inject(MAT_DIALOG_DATA) public data: AddUserModel[],private dialogRef: MatDialogRef<ManagerUserListDialog>) {
//     this.data.forEach(data => {
// data
//     });
  }
  selectedUser:any;

  displayedColumns: string[] = ['User_ID', 'First_Name', 'Last_Name', 'Employee_ID'];
  
  dataSource = new MatTableDataSource(this.data);

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  public onSave(element) {    
    this.dialogRef.close(element.User_ID);
  }
}