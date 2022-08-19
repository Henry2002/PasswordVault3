import { HttpClient } from '@angular/common/http';
import { Component, Inject, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Company } from '../../models/company';
import { WebService } from '../../services/WebService';


//only load the amount of data shown by the paginator//

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
})
export class CompaniesComponent {
 ;
  dataSource = new MatTableDataSource<Company>();
  displayedColumns=["Company ID","Company Name","Primary Contact","Actions"]
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private webService: WebService, private router: Router, private http: HttpClient) {
  
    
  }

}


