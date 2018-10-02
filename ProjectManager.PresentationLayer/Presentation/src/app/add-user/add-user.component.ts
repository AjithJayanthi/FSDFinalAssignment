import { Component, OnInit } from '@angular/core';
import { AddUserModel } from '../models/add-user.model';
import { ApiService } from '../api.service'

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  addUserModel:AddUserModel;
  UserModel:AddUserModel[];
  usersListCount:number;
  isUpdate:boolean;
  searchText:any;
  constructor(private apiService:ApiService) { 
    this.addUserModel = new AddUserModel();
    this.isUpdate = false;
  }

  ngOnInit() {
    this.getUsers("");
  }

public getUsers(soringParameter: string){
  this.apiService.getUsers(soringParameter).subscribe((data:AddUserModel[])=>{
    this.UserModel = data;
    console.log(data);
    this.usersListCount = data.length;
  })
}

  submitted = false;

  onSubmit() { 
    this.apiService.addUser(this.addUserModel).subscribe((data:boolean)=>{
      console.log("component :"+data);
      this.getUsers("");
      this.addUserModel.User_ID=null;
      this.isUpdate = false;
    })
   }

   editUser(user:AddUserModel){
    this.addUserModel.User_ID=user.User_ID;
    this.addUserModel.First_Name=user.First_Name;
    this.addUserModel.Last_Name=user.Last_Name;
    this.addUserModel.Employee_ID=user.Employee_ID;    
    this.isUpdate = true;
   }

   public deleteUser(user:AddUserModel){
    this.apiService.deleteUser(user).subscribe((data:boolean)=>{      
      console.log(data);
      this.getUsers("");
    })
  }

  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.addUserModel); 
}
}
