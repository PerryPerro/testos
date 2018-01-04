using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testos.Models;
using Logic;
using System.Data.Entity;
namespace Testos.Controllers
{
    public class ProfileController : BaseController
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
       public ActionResult SeeProfile()
        {
                var idet = User.Identity.GetUserId();
            var user = db.Users.Find(idet);
            return View(user);
        }
        public ActionResult EditProfile()
        {
            var idet = User.Identity.GetUserId();
            var user = db.Users.Find(idet);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditProfile(ApplicationUser user)
        {
            var idet = User.Identity.GetUserId();
            var us = db.Users.Find(idet);
            us.FirstName = user.FirstName;
            us.EfterNamn = user.EfterNamn;
            us.Age = user.Age;
            us.From = user.From;
            us.Gender = user.Gender;
                
            db.SaveChanges();
            return View();
        }

        public ActionResult SeeOtherProfile(string id)
        {
            var user = db.Users.Find(id);


            return View(new ProfileModel { Id = id, User = user });

        }
        public ActionResult ListOFUsers()
        {
            var users = db.Users.ToList();
            return View(users);

        }

    }
}