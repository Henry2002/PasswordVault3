import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Company } from '../../models/company';
import { Location } from '@angular/common'
import { Server } from '../../models/server';
import { WebService } from '../../services/WebService';

@Component({
  selector: 'add-edit-server',
  templateUrl: './add-edit-server.component.html',
})
export class AddEditServerComponent {

  baseUrl: string;
  server: any;


  constructor(private webService: WebService, private route: ActivatedRoute, private router: Router, private location: Location, @Inject('BASE_URL') baseUrl: string) {

    this.baseUrl = baseUrl;
    this.server = {};
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      var serverId = params.get('id');
      if (serverId) {
        this.webService.get('server/getserver/' + serverId, (res: Server) => {
          this.server= res
        });
      } else {
        this.server.companyId = params.get('companyid')
      }
    });
  }


  save() {
    this.webService.post('server/saveserver', this.server, () => {
        this.location.back()
      });
  }

  back() {
    this.location.back();
  }




}
