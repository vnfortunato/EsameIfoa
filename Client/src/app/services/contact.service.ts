import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Contact } from '../models/contact.type';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  private _http = inject(HttpClient)
  private readonly _url = 'https://localhost:44307/api/Contacts'

  public getAllContacts(): Observable<Contact[]> {
    return this._http.get<Contact[]>(this._url)
  }

  public postContact(contact: Contact): Observable<Contact> {
    return this._http.post<Contact>(this._url, contact)
  }
}
