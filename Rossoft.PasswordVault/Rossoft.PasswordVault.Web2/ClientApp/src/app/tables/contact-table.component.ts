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
import { DeleteDialogComponent } from './delete-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'contact-table',
  templateUrl: './contact-table.component.html',
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class ContactTableComponent {
  dataSourceC = new MatTableDataSource<Contact>();
  displayedColumnsC = ["Contact ID", "Contact Name", "Contact E-mail", "Contact Phone", "ActionsC"]
  companyId: any;
  activeAsString: string;
  @ViewChild(MatPaginator) paginatorC!: MatPaginator;



  constructor(private webService: WebService, private route: ActivatedRoute, private router: Router, private location: Location,public dialog: MatDialog) {
    ;

    this.companyId = {};
    this.activeAsString = "active"

  }
  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.companyId = params.get('id');
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

  addContact() {
    this.router.navigate(['/add-edit-contact/' + this.companyId])
  }

  removeContact(contact: Contact) {
    let contactToRemove = { id: contact.id, name: contact.name };
    let dialogRef = this.dialog.open(DeleteDialogComponent)
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.webService.post('contact/remove', contactToRemove, () => {
          this.loadData(this.companyId)
        });
      }
    });
  }

  addEditContact(contact: Contact) {
    this.router.navigate(['/add-edit-contact/', this.companyId, contact.id])
  }

}




