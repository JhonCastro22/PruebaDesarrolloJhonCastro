import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  errorMessage: string = '';

  constructor(private fb: FormBuilder, private http: HttpClient, private router: Router) {
    this.loginForm = this.fb.group({
      nombre: ['', [Validators.required]],
      password: ['', Validators.required]
    });
  }

  login() {
    console.log("Entra");
    if (this.loginForm.valid) {
      this.http.post('http://localhost:5283/api/login', this.loginForm.value).subscribe(
        (res: any) => {
          localStorage.setItem('token', res.token);
          this.router.navigate(['/inventario']); // Redirige a /inventario
        },
        (err) => {
          this.errorMessage = 'Usuario o contraseña incorrectos';
        }
      );
    }
  }
}