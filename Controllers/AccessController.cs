using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto_MVC.Models; 

namespace proyecto_MVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        { 
            return View();
        }
        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (BD_MVCEntities db = new BD_MVCEntities())
                {
                    var lst = from d in db.tbl_user   //Recrea el lenguaje sql
                              where d.email == user && d.password == password && d.idState==1
                              select d;
                    if (lst.Count() > 0)
                    {
                        tbl_user oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("Acceso Conecedido");

                    }else
                    {
                        return Content("Usuario Invalido");
                    }

                              }
                return Content("1");
            }
            catch(Exception ex)
            {
                return Content("Ocurrio un error :(" + ex.Message);
            }
        }
    }
}