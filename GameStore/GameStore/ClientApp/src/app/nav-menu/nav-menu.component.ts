import { Component } from '@angular/core';
import {AuthenticationService} from "../../shared/services/authentication.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  public isAuth:boolean;

  constructor(private _authService:AuthenticationService, private _router:Router) {
  }
  ngOnInit():void{
    this._authService.authChanged
      .subscribe(res => {
        this.isAuth = res;
      })
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public logout =() =>{
    this._authService.logout();
    this._router.navigate(["/"]);
  }
}
