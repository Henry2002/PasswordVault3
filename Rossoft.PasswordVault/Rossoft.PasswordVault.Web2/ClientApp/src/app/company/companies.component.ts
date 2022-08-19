import { HttpClient } from '@angular/common/http';
import { Component, Inject, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Company } from '../../models/company';
import { WebService } from '../../services/WebService';
import { DeleteDialogComponent } from './delete-dialog.component';

//only load the amount of data shown by the paginator//

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
})
export class CompaniesComponent {
  baseUrl: string;
  includeInactive: boolean;
  dataSource = new MatTableDataSource<Company>();
  displayedColumns=["Company ID","Company Name","Primary Contact","Actions"]
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private webService: WebService, private router: Router, @Inject('BASE_URL') baseUrl: string, public dialog: MatDialog, private http: HttpClient) {
    this.baseUrl = baseUrl
    this.includeInactive = false;
    this.loadData(this.includeInactive);
    
  }

  loadData(includeInactive: boolean) {
    this.webService.get('company/getslimcompanies/' + includeInactive.toString(), (res: any) => { 
        this.dataSource.data = res;
        this.dataSource.paginator = this.paginator;
      });
  }

  addCompany() {
    this.router.navigate(['add-edit-company'])
  }

  openCompany(company: Company) {
    this.router.navigate(['/veiw-company/'+company.id])
  }

  removeCompany(company:Company) {
    let dialogRef = this.dialog.open(DeleteDialogComponent)
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.webService.post('company/remove', company, () => {
            this.loadData(this.includeInactive)
          });
      }
    });
  }
}


