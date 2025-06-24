import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ContactService } from '../services/contact.service';

@Component({
  selector: 'app-contact-form',
  imports: [ReactiveFormsModule],
  templateUrl: './contact-form.component.html',
  styleUrl: './contact-form.component.scss'
})
export class ContactFormComponent {

  protected contactFormGroup!: FormGroup
  private _contactService = inject(ContactService);
  private _formBuilder = inject(FormBuilder);

  constructor() {
    this.contactFormGroup = this._formBuilder.group({
      fullName: ['', [Validators.required, Validators.maxLength(100)]],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.maxLength(15)]],
      department: ['', [Validators.required]]
    });
  }

  protected onSubmit(): void {
    if (this.contactFormGroup.valid) {
      const contact = this.contactFormGroup.value;
      this._contactService.postContact(contact).subscribe({
        next: (response) => {
          console.log('Contact added successfully:', response);
          this.contactFormGroup.reset();
        },
        error: (err) => {
          console.error('Error adding contact:', err);
        }
      });
    } else {
      console.error('Form is invalid');
    }
  }
}
