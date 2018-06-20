using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sublime.Database.Pocos;
using Sublime.Database.Repositories;
using Sublime.Models;

namespace Sublime.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ContactViewModel model = await ContactViewModel.Load();
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> EditContact(string firstName, string lastName, long personalNR, string email, long phone, string company, int companyId)
        {
            ActionResult result = null;
            Contact contact = new Contact();
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.Personalnr = personalNR;
            contact.Email = email;
            contact.Phone = phone;
            contact.CompanyName = company;

            await ContactViewModel.UpdateContact(contact);

            result = RedirectToAction("Index", "Home");
            return result;
        }

        public async Task<IActionResult> NewContact(string firstName, string lastName, long personalNR, string email, long phone, string company, int companyId)
        {
            ActionResult result = null;
            Contact contact = new Contact();
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.Personalnr = personalNR;
            contact.Email = email;
            contact.Phone = phone;
            contact.CompanyName = company;

            await ContactViewModel.NewContact(contact);

            result = RedirectToAction("Index", "Home");
            return result;
        }
    }
}
