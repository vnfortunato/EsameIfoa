import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ContactService } from '../services/contact.service';
import { HttpSuccessMessage } from '../models/http-success-message.type';

@Component({
  selector: 'app-contact-form',
  imports: [ReactiveFormsModule],
  templateUrl: './contact-form.component.html',
  styleUrl: './contact-form.component.scss'
})

// ContactFormComponent is responsible for creating a contact form
export class ContactFormComponent {

  protected contactFormGroup!: FormGroup
  private _contactService = inject(ContactService);
  private _formBuilder = inject(FormBuilder);

  // Builds the contact form with validation 
  constructor() {
    this.contactFormGroup = this._formBuilder.group({
      fullName: ['', [Validators.required, Validators.maxLength(100)]],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.maxLength(15)]],
      department: ['', [Validators.required]]
    });
  }

  // Sends the contact data to the server when the form is submitted
  protected onSubmit(): void {
    if (this.contactFormGroup.valid) {
      const contact = this.contactFormGroup.value;
      this._contactService.postContact(contact).subscribe({
        next: (response: HttpSuccessMessage) => {
          alert(response.message);
          this.contactFormGroup.reset();
        },
        error: (err) => {
          alert(err.error.message);
        }
      });
    } else {
      console.error('Form is invalid');
    }
  }
}
