using Sublime.Database.Pocos;
using Sublime.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sublime.Models
{
    public class ContactViewModel
    {
        public List<Contact> Contacts;
        public List<string> Companies;

        public static async Task<ContactViewModel> Load()
        {
            ContactViewModel model = new ContactViewModel();
            ContactRepository repo = new ContactRepository();
            model.Contacts = repo.Contacts.ToList();
            model.Companies = repo.Companies.ToList();

            return model;
        }

        public static async Task<int>UpdateContact(Contact contact)
        {
            ContactRepository repo = new ContactRepository();

            return await repo.UpdateContactAsync(contact);
        }

        public static async Task<int> NewContact(Contact contact)
        {
            ContactRepository repo = new ContactRepository();

            return await repo.NewContactAsync(contact);
        }

    }
}
