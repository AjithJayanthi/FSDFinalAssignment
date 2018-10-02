export class AddTaskModel {
    Task_ID: number;
    Parent_ID?: number;
    Project_ID: number;
    Task: string;
    Start_Date?: Date;
    End_Date?: Date
    Priority?: number;
    User_ID:number;
    isParentTask:boolean;
    ParentTaskTitle:string;
    Status:boolean;
}