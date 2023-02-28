using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Models;

namespace MovieList.Controllers
{
    public class ContactController : Controller
    {
        private ContactContext context { get; set; }

        public ContactController(ContactContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categorys = context.Categorys.OrderBy(f => f.Name).ToList();
            return View("Edit", new ContactInfo());
        }
        public IActionResult Details(int id)
        {
            ViewBag.Action = "Details";
            ViewBag.Categorys = context.Categorys.OrderBy(g => g.Name).ToList();
            var contact = context.ContactInfos.Find(id);
            return View(contact);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categorys = context.Categorys.OrderBy(f => f.Name).ToList();
            var contact = context.ContactInfos.Find(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactInfoID == 0)
                    context.ContactInfos.Add(contact);
                else
                    context.ContactInfos.Update(contact);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (contact.ContactInfoID == 0) ? "Add" : "Edit";
                ViewBag.Categorys = context.Categorys.OrderBy(f => f.Name).ToList();
                return View(contact);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.ContactInfos.Find(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(ContactInfo contact)
        {
            context.ContactInfos.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}