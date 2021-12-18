import { UserForRegistrationDto } from "../../_interfaces/user/userForRegistrationDto";
import { AuthenticationService} from "../../../shared/services/authentication.service";
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {

  public registerForm: FormGroup;

  constructor(private _authService: AuthenticationService) { }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      confirmPassword: new FormControl('', [Validators.required])
    });
  }

  public validateControl = (controlName:string) => {
    return this.registerForm.controls[controlName].invalid && this.registerForm.controls[controlName].touched;
  }
  public hasError = (controlName:string, errorName: string) => {
    return this.registerForm.controls[controlName].hasError(errorName);
  }
  public registerUser = (registerFormValue) => {
    const formValues = {...registerFormValue};

    const user: UserForRegistrationDto = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirmPassword
    };

    this._authService.registerUser("api/accounts/registration", user)
      .subscribe(_ =>{
        console.log("Success")
      }, error =>{
        console.log(error.error.errors);
      })
    }
}
