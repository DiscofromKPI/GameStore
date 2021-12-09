import { Injectable } from '@angular/core';
import {RegistrationResponseDto} from "../../app/_interfaces/response/registrationResponseDto";
import {UserForRegistrationDto} from "../../app/_interfaces/user/userForRegistrationDto";
import {HttpClient} from "@angular/common/http";
import {Environment} from "@angular/compiler-cli/src/ngtsc/typecheck/src/environment";



@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private _http:HttpClient, private _envUrl:Environment) { }

  public registerUser = (route:string, body:UserForRegistrationDto) => {
    return this._http.post<RegistrationResponseDto>(this.createCompleteRoute(route, this._envUrl.urlAddress), body)
  }

  private createCompleteRoute = (route: string, envAddress: string) => {
    return `${envAddress}/${route}`;
  }
}
