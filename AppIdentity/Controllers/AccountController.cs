using AppIdentity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AppIdentity.Controllers
{    
    public class AccountController : Controller
    {
        private AppIdentityDBContext db = new AppIdentityDBContext();
       
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
            //return View(db.Users.ToList().Where(x => x.Approved == "true"));
        }
          
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Login(User u)
        {
            AppIdentityDBContext db = new AppIdentityDBContext();
            var count = db.Users.Where(x => x.Username == u.Username && x.Password == u.Password).Count();
            var checkuser = db.Users.Where(x => x.Username == u.Username && x.Password == u.Password && x.Role=="p").Count();
            if (count == 0)
            {
                ViewBag.Msg = "Invalid User!";
                return View();
            }

            else if (checkuser != 0)
            {
                ViewBag.Mssg = "Your account is waiting for approval!";
                return View();
            }

            else
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return RedirectToAction("Index", "Home");
            }
                                   
        }
     
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
        public ActionResult Register()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                var checkUser = db.Users.Where(x => x.Username == u.Username).Count();
                if (checkUser == 0)
                {
                    using (AppIdentityDBContext db = new AppIdentityDBContext())
                    {
                        u.Role = "p";
                        u.Approved = "pending";
                        db.Users.Add(u);
                        db.SaveChanges();
                        ModelState.Clear();
                        u = null;
                        ViewBag.Msg = "Successfully registered.";
                    }
                }
                else
                {
                    ViewBag.Msg = "That username is already taken, try another one.";
                    return View(u);
                }
            }
            return View(u);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
