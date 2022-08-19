import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Company } from '../../models/company';
import { Location } from '@angular/common'
import { Contact } from '../../models/contact';
import { Server } from '../../models/server';
import { WebService } from '../../services/WebService';
import { AuthResult } from '../../models/authresult';
import { BaseResult } from '../../models/baseresult';

//merge the add-edit company components//

@Component({
  selector: 'add-edit-company',
  templateUrl: './add-edit-company.component.html',
})
export class AddEditCompanyComponent {
  baseUrl: string;
  company: any;
  companyId: any;

  constructor(private webService: WebService, private route: ActivatedRoute, private router: Router, private location: Location, @Inject('BASE_URL') baseUrl: string) {
    this.webService = webService;
    this.baseUrl = baseUrl;
    this.company = {}
  
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.companyId = params.get('id');
      if (this.companyId) {
        this.webService.get('company/getslimcompany/' + this.companyId, (res: Company) => {
          this.company = res
        });

      }
    });
  }

  save() {
    this.webService.post('company/save', this.company, () => {
      this.back()
    });
  }
      

  back() {
    this.location.back();
  }
}
