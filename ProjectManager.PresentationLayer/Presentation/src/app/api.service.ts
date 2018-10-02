import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from  '@angular/common/http';
import { AddUserModel } from './models/add-user.model';
import { observable, Observable, of } from '../../node_modules/rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { AddProjectModel } from './models/add-project.model';
import { AddTaskModel } from './models/add-task.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
base_url="http://localhost/ProjectManagerService";
httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
  constructor(private  httpClient:  HttpClient) { }
  getUsers(soringParameter :string):Observable<AddUserModel[]>{
    return  this.httpClient.get<AddUserModel[]>(`${this.base_url}/User/GetUsers?soringParameter=`+soringParameter);
}

addUser (addUserModel:AddUserModel): Observable<boolean> {
  
  return this.httpClient.post<boolean>(`${this.base_url}/User/AddUser`,JSON.stringify(addUserModel), this.httpOptions).pipe(
    tap((isAdded: boolean) => console.log(`added user : ${isAdded}`)),
    catchError(this.handleError<boolean>('addUser'))
  );
}

deleteUser (addUserModel:AddUserModel): Observable<boolean> {
  
  return this.httpClient.post<boolean>(`${this.base_url}/User/DeleteUser`,JSON.stringify(addUserModel), this.httpOptions).pipe(
    tap((isAdded: boolean) => console.log(`deleted user : ${isAdded}`)),
    catchError(this.handleError<boolean>('DeleteUser'))
  );
}

getProjects():Observable<AddProjectModel[]>{
  return  this.httpClient.get<AddProjectModel[]>(`${this.base_url}/Project/GetProjects`);
}

addProject (addProjectModel:AddProjectModel): Observable<boolean> {
  
  return this.httpClient.post<boolean>(`${this.base_url}/Project/AddProject`,JSON.stringify(addProjectModel), this.httpOptions).pipe(
    tap((isAdded: boolean) => console.log(`added project : ${isAdded}`)),
    catchError(this.handleError<boolean>('addProject'))
  );
}

deleteProject (addProjectModel:AddProjectModel): Observable<boolean> {
  
  return this.httpClient.post<boolean>(`${this.base_url}/Project/DeleteProject`,JSON.stringify(addProjectModel), this.httpOptions).pipe(
    tap((isAdded: boolean) => console.log(`deleted project : ${isAdded}`)),
    catchError(this.handleError<boolean>('DeleteProject'))
  );
}

addTask (addProjectModel:AddTaskModel): Observable<boolean> {
  
  return this.httpClient.post<boolean>(`${this.base_url}/Task/AddTask`,JSON.stringify(addProjectModel), this.httpOptions).pipe(
    tap((isAdded: boolean) => console.log(`added task : ${isAdded}`)),
    catchError(this.handleError<boolean>('addTask'))
  );
}

getParentTasks():Observable<AddTaskModel[]>{
  return  this.httpClient.get<AddTaskModel[]>(`${this.base_url}/Task/GetParentTasks`);
}

getTasks(sortingParameter:string):Observable<AddTaskModel[]>{
  return this.httpClient.get<AddTaskModel[]>(`${this.base_url}/Task/GetTasks?sortingParameter=`+sortingParameter);
}

endTask(task:AddTaskModel):Observable<boolean>{
  return this.httpClient.post<boolean>(`${this.base_url}/Task/EndTask`,JSON.stringify(task), this.httpOptions).pipe(
    tap((isDeleted: boolean) => console.log(`deleted task : ${isDeleted}`)),
    catchError(this.handleError<boolean>('EndTask'))
  );
}

/**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
private handleError<T> (operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {

    // TODO: send the error to remote logging infrastructure
    console.error(error); // log to console instead

    // TODO: better job of transforming error for user consumption
    console.log(`${operation} failed: ${error.message}`);

    // Let the app keep running by returning an empty result.
    return of(result as T);
  };
}

}
