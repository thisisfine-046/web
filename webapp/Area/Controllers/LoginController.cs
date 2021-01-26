using Model1.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapp.Area.Models;
using webapp.Common;
using Model1.EF;

namespace webapp.Area.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var resultadmin = dao.AdminLogin(model.userName, model.passWord);
                var resultuser = dao.UserLogin(model.userName, model.passWord);

                
                if (resultuser == true)
                {

                    var user = dao.GetById(model.userName);

                    var userSession = new UserLogin();
                    userSession.UserName = user.username;
                    userSession.UserID = user.uid;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return View("UserPage");
                }
                if (resultadmin == true)
                {

                    var user = dao.GetById(model.userName);

                    var userSession = new UserLogin();
                    userSession.UserName = user.username;
                    userSession.UserID = user.uid;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return View("AdminPage");
                }

                else
                {
                    ModelState.AddModelError("", "Login Fail");
                }

            }
            
            return View("Index");

        }






        //// GET: User


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }


        [HttpPost]
        public ActionResult Create(ulogin user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                long id = dao.Insert1(user);
                if (id > 0)
                {
                    return RedirectToAction("Create", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thành công");
                }
            }
            return View("Create");
        }
        [HttpPost]
        public ActionResult Edit(ulogin user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                bool result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Edit", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user thành công");
                }
            }
            return View("Edit");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var user = new UserDao();
            try
            {
                user.Delete(id);
                return RedirectToAction("AdminPage");
            }
            catch
            {
                return RedirectToAction("AdminPage");
            }
        }

    }
}