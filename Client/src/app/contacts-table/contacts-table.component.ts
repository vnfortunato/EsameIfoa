import { Component, inject, signal } from '@angular/core';
import { ContactService } from '../services/contact.service';
import { Contact } from '../models/contact.type';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contacts-table',
  imports: [],
  templateUrl: './contacts-table.component.html',
  styleUrl: './contacts-table.component.scss'
})

// ContactsTableComponent is responsible for displaying a list of contacts
export class ContactsTableComponent {

  protected contacts = signal<Contact[]>([]);
  private _contactService = inject(ContactService);
  private _router = inject(Router);

  constructor() {
    this.loadContacts();
  }

  // Navigates to the contact form for adding a new contact
  protected onAddContact(): void {
    this._router.navigate(['/contact-form']);
  }

  // Loads all contacts from the server and set them to the contacts signal
  private loadContacts(): void {
    this._contactService.getAllContacts().subscribe({
      next: (contacts) => {
        this.contacts.set(contacts);
      },
      error: (err) => {
        alert(err.error.message);
      }
    });
  }

}
