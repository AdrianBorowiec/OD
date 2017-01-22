using FluentValidation.Results;
using OD.DAL;
using OD.Domain.Validators;
using OD.Infrastructure;
using OD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OD.Controllers
{
    public class CustomerController : Controller
    {
        private Db db = new Db();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (db.Customers.Any(x => x.Nickname == customer.Nickname))
                {
                    ModelState.AddModelError(string.Empty, "Podany użytkownik już istnieje w bazie danych, proszę spróbować ponownie.");
                    return View();
                }

                if (customer.Password != customer.CheckPassword)
                {
                    ModelState.AddModelError(string.Empty, "Podane hasła się nie zgadzają, proszę spróbować ponownie.");
                    return View();
                }

                var key = Hashing.GeneratePassword(10);
                var encodedPassword = Hashing.EncodePassword(customer.Password, key);

                customer.Password = encodedPassword;
                customer.Code = key;

                db.Customers.Add(customer);
                db.SaveChanges();

                return View("SignInSuccess");
            }

            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Customer model)
        {
            var customer = db.Customers.FirstOrDefault(x => x.Nickname == model.Nickname);

            if (customer == null)
            {
                ModelState.AddModelError(string.Empty, "Podany użytkownik nie został znaleziony w bazie, proszę spróbować ponownie.");
                return View();
            }

            var code = customer.Code;
            var encodedPassword = Hashing.EncodePassword(model.Password, code);

            if (customer.Password != encodedPassword)
            {
                ModelState.AddModelError(string.Empty, "Podane hasło jest niepoprawne, spróbuj ponownie");
                return View();
            }

            Session["CustomerId"] = customer.Id;

            return RedirectToAction("Index", "Products");
        }

        public ActionResult LogOut()
        {
            Session.Remove("CustomerId");

            return RedirectToAction("Index", "Products");
        }
    }
}