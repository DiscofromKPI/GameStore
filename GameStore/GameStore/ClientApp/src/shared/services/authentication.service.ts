import { Injectable } from '@angular/core';
import {RegistrationResponseDto} from "../../app/_interfaces/response/registrationResponseDto";
import {UserForRegistrationDto} from "../../app/_interfaces/user/userForRegistrationDto";
import {HttpClient} from "@angular/common/http";
import {EnvironmentUrlService } from './environment-url.service';
import {UserForAuthenticationDto} from "../../app/_interfaces/user/userForAuthenticationDto";



@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private _http:HttpClient, private _envUrl:EnvironmentUrlService) { }

  public registerUser = (route:string, body:UserForRegistrationDto) => {
    return this._http.post<RegistrationResponseDto>(this.createCompleteRoute(route, this._envUrl.urlAddress), body)
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }

  public loginUser = (route:string, body:UserForAuthenticationDto) =>{
    return this._http.post(this.createCompleteRoute(route, this._envUrl.urlAddress), body);
  }
}
