using System.Net;
using JusTeeth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JusTeeth.App.Areas.Administration.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using JusTeeth.Data;

namespace JusTeeth.App.Areas.Administration.Controllers
{
    public class AdminUsersController : BaseController
    {
        // GET: /Administration/Users/
        public ActionResult Index()
        {
            var users = this.Db.UsersRepository.All();
            return View(users);
        }

        //
        // GET: /Administration/Users/Details/5
        public ActionResult Details(string username)
        {
            var user = this.Db.UsersRepository.All().FirstOrDefault(x => x.UserName == username);
            return View(user);
        }

        //
        // GET: /Administration/Users/Edit/5
        public ActionResult Edit(string username)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            if (username == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            bool isAdmin = false;
            var user = Db.UsersRepository.All().FirstOrDefault(x => x.UserName == username);
            var role = user.Roles.FirstOrDefault(x => x.Role.Name == "Admin");
            if (role != null)
            {
                isAdmin = true;
            }

            ApplicationUserViewModel userVM = new ApplicationUserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                Avatar = user.Avatar,
                DisplayName = user.DisplayName,
                FacebookProfile = user.FacebookProfile,
                IsAdmin = isAdmin
            };


            if (user == null)
            {
                return HttpNotFound();
            }

            return View(userVM);
        }

        //
        // POST: /Administration/Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUserViewModel user)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            if (ModelState.IsValid)
            {
                var editedUser = db.Users.FirstOrDefault(x => x.Id == user.Id);
                editedUser.DisplayName = user.DisplayName;
                editedUser.Avatar = user.Avatar;
                editedUser.FacebookProfile = user.FacebookProfile;
                var role = db.Roles.FirstOrDefault(x => x.Name == "Admin");
                var userRole = new UserRole() { Role = role };
                if (user.IsAdmin)
                {
                    editedUser.Roles.Add(userRole);
                }
                else
                {
                    editedUser.Roles.Clear();
                }

                db.SaveChanges();


                //Db.UsersRepository.Update(editedUser);
                //Db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
    }
}
