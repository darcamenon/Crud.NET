using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto_MVC.Models;
using proyecto_MVC.Models.tableViewModels;
using proyecto_MVC.Models.ViewModels;


namespace proyecto_MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using(BD_MVCEntities db=  new BD_MVCEntities())
            {
                lst = (from d in db.tbl_user
                       where d.idState == 1
                       orderby d.email
                       select new UserTableViewModel
                       {
                           Email = d.email,
                           Id = d.Id_usuario,
                           Edad = d.edad
                       }).ToList();
            }

            return View(lst);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]// Me sirve para hacer que este metodo solo entre por POST
        public ActionResult Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new BD_MVCEntities())
            {
                tbl_user oUser = new tbl_user();
                oUser.idState = 1;
                oUser.email = model.Email;
                oUser.edad = model.Edad;
                oUser.password = model.Password;

                db.tbl_user.Add(oUser);

                db.SaveChanges();

            }

            return Redirect(Url.Content("~/User/"));

        }


        public ActionResult Edit(int Id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new BD_MVCEntities())
            {
               var oUser = db.tbl_user.Find(Id);
                model.Edad = (int)oUser.edad;
                model.Email = oUser.email;
                model.Id = oUser.Id_usuario;
            }


            return View(model);
        }

        [HttpPost]// Me sirve para hacer que este metodo solo entre por POST
        public ActionResult Edit(EditUserViewModel model)

        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new BD_MVCEntities())
            {
               var oUser = db.tbl_user.Find(model.Id);
                oUser.email = model.Email;
                oUser.edad = model.Edad;

                if(model.Password !=null && model.Password.Trim() != "")
                {
                    oUser.password = model.Password; // Si se cambia el password o si queda el que ya estaba
                }
                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));

        }



    }
}