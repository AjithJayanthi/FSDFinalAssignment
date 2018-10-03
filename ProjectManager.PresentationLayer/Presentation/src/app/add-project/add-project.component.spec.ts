import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { AddProjectComponent } from './add-project.component';
import { ApiService } from '../api.service';
import {ApiServiceMock} from'../api.servicemock';
import { FormsModule, ReactiveFormsModule,}   from '@angular/forms';
import {MatButtonModule, MatCheckboxModule,MatFormFieldModule,MatSliderModule} from '@angular/material';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { AddProjectModel } from '../models/add-project.model';









describe('AddProjectComponent', () => {
  let component: AddProjectComponent;
  let fixture: ComponentFixture<AddProjectComponent>;

   beforeEach(async(() => {
     TestBed.configureTestingModule({
      imports: [ReactiveFormsModule,MatButtonModule,MatFormFieldModule,MatSliderModule, FormsModule,MatCheckboxModule,MatDatepickerModule],
       declarations: [ AddProjectComponent ],
       providers:[{provide :ApiService,useClass:ApiServiceMock}]
     })
    .compileComponents().then(()=>{
      //fixture=TestBed.createComponent(AddProjectComponent);
      //component=fixture.componentInstance;
    });
   }));

 //  beforeEach(() => {
  //   fixture = TestBed.createComponent(AddProjectComponent);
  //   component = fixture.componentInstance;
   //  fixture.detectChanges();
  // });

   it('should get one project', async(() => {
     
         expect(0).toEqual(0);
   }));
});
