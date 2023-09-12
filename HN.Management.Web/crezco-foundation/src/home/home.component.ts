import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  // @ts-ignoretypes
  newsletterForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.newsletterForm = this.formBuilder.group({
      letterEmail: ['', [Validators.required, Validators.email]],
    });
  }

  showAlert() {
    Swal.fire({
      position: 'center',
      icon: 'success',
      title: 'Tu mensaje ha sido enviado',
      showConfirmButton: false,
      timer: 2000,
    });
    this.newsletterForm.reset({});
  }

  onSubmited() {
    // TODO: Agregar la url del backend
    console.log(this.newsletterForm.status);
    console.log(this.newsletterForm.value);
    this.showAlert();
  }
}
