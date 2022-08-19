import { HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { catchError, filter, Observable } from 'rxjs';
import { AuthorizeService } from '../../api-authorization/authorize.service';


@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  showSearch: boolean

  constructor(private route: ActivatedRoute, private router: Router, private authService: AuthorizeService) {
    this.showSearch = false;
    this.router.events.subscribe(event=> {
      if (authService.isAuthenticated()) {
        this.showSearch = true
      } else {
        this.showSearch = false
      }
    });
  }

  isExpanded = false;
  searchPhrase: string=""
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  search() {
    this.router.navigate(['/search/' + this.searchPhrase])
  }
}
