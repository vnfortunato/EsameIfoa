import { Routes } from '@angular/router';

export const routes: Routes = [
{path: '', loadComponent: () => import('./contacts-table/contacts-table.component').then(m => m.ContactsTableComponent)},
{path: 'contact-form', loadComponent: () => import('./contact-form/contact-form.component').then(m => m.ContactFormComponent)}
];
