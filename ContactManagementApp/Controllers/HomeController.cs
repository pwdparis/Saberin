using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactManagementApp.Models;

namespace ContactManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext db = new ContactContext();
        public ActionResult Index()
        {
            var data = db.People.ToList();
            return View(data); 
        }

        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            var filteredData =
                db.People.Where(p =>
                    p.FirstName.Contains(searchTerm) ||
                    p.LastName.Contains(searchTerm) ||
                    p.EmailAddresses.Select(k => k.EmailAddressContent).Contains(searchTerm)
                );

            return Json(filteredData.ToList());
        }

        public ActionResult Clear()
        {
            var data = db.People.ToList();
            return Json(data);
        }

        [HttpGet]
        public ActionResult NewContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewContact(Models.Person person)
        {
            var successful = false;

            try
            {
                db.People.Add(person);
                db.SaveChanges();

                successful = true;
            }
            catch (Exception ex)
            {
                //todo: add logging
                
            }

            return Json(successful);
        }

        [HttpPost]
        public ActionResult EditContact(Models.Person person)
        {
            var successful = false;

            try
            {
                var personToEdit = db.People.Where(a => a.ID == person.ID).FirstOrDefault();
                personToEdit.FirstName = person.FirstName;
                personToEdit.LastName = person.LastName;

                personToEdit.EmailAddresses.Clear();

                foreach (var emailObj in person.EmailAddresses)
                {
                    personToEdit.EmailAddresses.Add(emailObj);
                }                

                db.SaveChanges();

            
                successful = true;
            }
            catch (Exception ex)
            {
                //todo: add logging

            }

            var data = db.People.ToList();
            return Json(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            var data = db.People.ToList();
            return View(data);
        }
    }
}