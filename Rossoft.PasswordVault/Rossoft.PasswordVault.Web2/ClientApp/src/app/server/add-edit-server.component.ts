import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Company } from '../../models/company';
import { Location } from '@angular/common'
import { Server } from '../../models/server';

@Component({
  selector: 'add-edit-server',
  templateUrl: './add-edit-server.component.html',
})
export class AddEditServerComponent {
  http: HttpClient;
  baseUrl: string;
  server: any;


  constructor(http: HttpClient, private route: ActivatedRoute, private router: Router, private location: Location, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
    this.server = {};
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      var serverId = params.get('id');
      if (serverId) {
        this.http.get('server/getserver/' + serverId).subscribe(result => {
          this.server= result
        });
      } else {
        this.server.companyId = params.get('companyid')
      }
    });
  }


  save() {
    this.http.post('server/saveserver', this.server)
      .subscribe(result => {
        this.location.back()
      });
  }

  back() {
    this.location.back();
  }




}
