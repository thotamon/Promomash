import { Component, Inject } from '@angular/core';
import {
  FormControl,
  FormGroupDirective,
  NgForm,
  Validators,
  FormsModule,
  ReactiveFormsModule,
  FormGroup,
  ValidatorFn,
  AbstractControl,
  ValidationErrors,
} from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';


/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}


/** @title Input with a custom ErrorStateMatcher */
@Component({
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css'],
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatInputModule, ReactiveFormsModule, CommonModule, MatCheckboxModule, MatButtonModule, MatSelectModule],
})
export class LoginFormComponent {
  step = 'login';
  countries: Country[] = [];
  provinces: Province[] = [];
  baseUrl: string = "";
  http: HttpClient;

  constructor(private router: Router,
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    http.get<Country[]>(baseUrl + 'users/countries').subscribe(result => {
      this.countries = result;
    }, error => console.error(error));

    this.http = http;
    this.baseUrl = baseUrl;
  }

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.pattern('^(?=.*[a-zA-Z])(?=.*[0-9]).{2,}$')]),
    passwordConfirmation: new FormControl('', [Validators.required]),
    agree: new FormControl('', [Validators.required])
  }, { validators: confirmPasswordValidator });

  countryForm = new FormGroup({
    country: new FormControl('', [Validators.required]),
    province: new FormControl('', [Validators.required])
  });

  matcher = new MyErrorStateMatcher();

  onSubmit(event: any) {
    if (!this.loginForm.valid)
      return;

    this.step = "selectCountry";
  }

  onSelectCountry(event: any) {
    this.http.get<Province[]>(this.baseUrl + 'users/provinces?countryId=' + event.value).subscribe(result => {
      this.provinces = result;
    }, error => console.error(error));
  }

  onSave(event: any) {
    if (!this.countryForm.valid)
      return;

    const user: User = {
      agree: true,
      id: 0,
      name: this.loginForm.get('email')!.value!,
      password: this.loginForm.get('password')!.value!,
      provinceId: <unknown>this.countryForm.get('province')!.value! as number
    };

    this.http.post(this.baseUrl + 'users', user).subscribe(result => {
      // for example, save user id
    }, error => console.error(error));
  }
}

export const confirmPasswordValidator: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {
  const password = control.get('password');
  const confirmPassword = control.get('passwordConfirmation');

  return password && confirmPassword && password.value === confirmPassword.value ? null : { passwordConfirmation: true };
};

interface Country {
  id: number;
  name: string;
}

interface Province {
  id: number;
  name: string;
  countryId: number;
}

interface User {
  id: number;
  name: string;
  password: string;
  agree: boolean;
  provinceId: number;
}
