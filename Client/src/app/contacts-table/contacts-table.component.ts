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
export class ContactsTableComponent {

  protected contacts = signal<Contact[]>([]);
  private _contactService = inject(ContactService);
  private _router = inject(Router);

  constructor() {
    this.loadContacts();
  }

  protected onAddContact(): void {
    this._router.navigate(['/contact-form']);
  }

  private loadContacts(): void {
    this._contactService.getAllContacts().subscribe({
      next: (contacts) => {
        this.contacts.set(contacts);
      },
      error: (err) => {
        console.error('Error loading contacts:', err);
      }
    });
  }

}
