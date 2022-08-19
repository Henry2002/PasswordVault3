import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Company } from '../../models/company';
import { WebService } from '../../services/WebService';

@Component({
  selector: 'search',
  templateUrl: './search.component.html',
})
export class SearchComponent {
  baseUrl: string;
  searchPhrase: any;
  public searchOption = "Company";
  searchOptions = ["Company", "Contact", "Server"]
  searchResults: any;
  dataSource = new MatTableDataSource<Company>();
  displayedColumns = ["Company ID", "Company Name", "Actions"]
 
  constructor(private webService:WebService, private router: Router, private route: ActivatedRoute, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl; 
    this.searchPhrase = "";
  }

  ngOnInit() {
      this.route.paramMap.subscribe(params => {
        this.searchPhrase = params.get('searchphrase');
      });
    this.loadData();
  }

  search(searchphrase: string, searchoption: string) {
    this.webService.get('search/search/' + searchphrase + "/" + searchoption,(res:Array<Company>)=> {
        this.dataSource.data = res;
      });

  }

  loadData() {
    this.search(this.searchPhrase, this.searchOption);
  }

  openCompany(company: Company) {
    this.router.navigate(['/veiw-company/' + company.id])
  }

  //this method needs its alert thing taking out and a dialog putting in//
  removeCompany(company: Company) {
    if (confirm("Are you sure you wish to delete " + company.name + "?")) {
      this.webService.post('company/remove', company,()=> {
          alert("company deleted with name:" + company.name);
          this.loadData();
        });


    }


  }
  }
