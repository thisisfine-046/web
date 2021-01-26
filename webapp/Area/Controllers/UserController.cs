using Model1.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model1.EF;
namespace webapp.Area.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

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
                    return View("CreatedUser", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thành công");
                }
            }
            return View("Index");
        }
    }
}