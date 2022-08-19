import { HttpClient } from '@angular/common/http';
import { Component, Inject, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Contact, ContactToRemove } from '../../models/contact';
import { Company } from '../../models/company';
import { Server, ServerToRemove } from '../../models/server'
import { Location } from '@angular/common'
import { MatTableDataSource } from '@angular/material/table';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { WebService } from '../../services/WebService';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'veiw-company',
  templateUrl: './veiw-company.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class VeiwCompanyComponent {
  baseUrl: string;
  company: any;
  dataSourceC = new MatTableDataSource<Contact>();
  displayedColumnsC = ["Contact ID", "Contact Name", "Contact E-mail", "Contact Phone", "Actions"]
  companyId: any;
  activeAsString: string;
  @ViewChild(MatPaginator) paginatorC!: MatPaginator;



  constructor(private webService: WebService, private route: ActivatedRoute, private router: Router, private location: Location, @Inject('BASE_URL') baseUrl: string, public dialog: MatDialog) {
    ;
    this.baseUrl = baseUrl;
    this.company = {};
    this.companyId = {};
    this.activeAsString = "active"

  }
  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.companyId = params.get('id');
      if (this.companyId) {
        this.webService.get('company/getslimcompany/' + this.companyId, (res: Company) => {
          this.company = res
          this.activeAsString = this.getActiveAsString(this.company.active);
        });

      }
    });
    this.loadData(this.companyId);
  }

  loadData(companyId: number) {
    if (companyId) {
      this.webService.get('contact/getslimcontacts/' + companyId, (res: Array<Contact>) => {
        this.dataSourceC.data = res;
        this.dataSourceC.paginator = this.paginatorC;
      });

    }
  }


  back() {
    this.router.navigate(['/']);
  }

  addEditCompany(company: Company) {
    this.router.navigate(['/add-edit-company/' + company.id])
  }

  getActiveAsString(active: boolean) {
    if (active) {
      return "Active"
    } else {
      return "Inactive"
    }
  }

  
}



