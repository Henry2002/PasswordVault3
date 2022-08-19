import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Company } from '../../models/company';
import { Location } from '@angular/common'
import { Contact } from '../../models/contact';
import { OverwritePrimaryDialogComponent } from './overwrite-primary-dialog';
import { MatDialog } from '@angular/material/dialog';
import { WebService } from '../../services/WebService';

@Component({
  selector: 'add-edit-contact',
  templateUrl: './add-edit-contact.component.html',
})
export class AddEditContactComponent {

  baseUrl: string;
  contact: any;
  companyId: any;

  constructor(private webService: WebService, private route: ActivatedRoute, private router: Router, private location: Location, @Inject('BASE_URL') baseUrl: string, public dialog: MatDialog) {
    this.baseUrl = baseUrl;
    this.contact = {};
    this.dialog = dialog;
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      var contactId = params.get('id');
      this.companyId=params.get('companyid')
      if (contactId) {
        this.webService.get('contact/getcontact/' + contactId,(res:Contact) => {
          this.contact = res
        });
      } else if (this.companyId) {
        this.contact.companyId = params.get('companyid')
      }
    });
  }


  save() {
    this.webService.post('contact/savecontact', this.contact, (res: string) => {
      const boolres = res === 'true'
        if (!boolres) {
          let dialogRef = this.dialog.open(OverwritePrimaryDialogComponent)
          dialogRef.afterClosed().subscribe(result => {
            if (result) {
              this.webService.post('contact/makeprimarycontact', this.contact,() => {
                this.router.navigate(['./view-company/' + this.companyId])
              })
              
            }
          });

        } else { this.location.back() }
      });
  }

  back() {
    this.location.back()
  }




}
