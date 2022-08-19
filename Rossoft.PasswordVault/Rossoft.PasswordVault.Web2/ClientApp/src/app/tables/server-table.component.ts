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
  selector: 'server-table',
  templateUrl: './server-table.component.html',
})

export class ServerTableComponent {

  companyId:any
  displayedColumnsS = ["Server ID", "Server Name", "Server Address", "Server Username", "Server Password", "Actions"]
  dataSourceS = new MatTableDataSource<Server>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private webService: WebService, private route: ActivatedRoute, private router: Router, private location: Location, public dialog: MatDialog) {
    this.companyId = {};

  }
  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.companyId = params.get('id');
  });
    this.loadData(this.companyId);
  }

  loadData(companyId:string) {
    this.webService.get('server/getslimservers/' + companyId, (res: Array<Server>) => {
      this.dataSourceS.data = res;
      this.dataSourceS.paginator = this.paginator;
    });
  }
  addServer() {
    this.router.navigate(['/add-edit-server/' + this.companyId])
  }

  removeServer(server: Server) {
    let serverToRemove = { id: server.id, name: server.name };
    let dialogRef = this.dialog.open(DeleteDialogComponent)
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.webService.post('server/remove', serverToRemove, () => {
          this.loadData(this.companyId)
        });
      }
    });
  }
  addEditServer(server: Server) {
    this.router.navigate(['/add-edit-server/', this.companyId, server.id])
  }

  toggleRow(server: { isExpanded: boolean; }) {
    server.isExpanded = !server.isExpanded
  }
}

