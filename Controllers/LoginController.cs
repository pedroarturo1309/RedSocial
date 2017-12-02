using RedSocial.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RedSocial.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            if (Session["cedula"] != null)
                return RedirectToAction("index", "home");

            if (ModelState.IsValid)
            {
                bool entra = false;
                using (var db = new Models.RedSocialDB())
                {
                    string pwd = UtilityMethods.SetSHA1(form["pass"]);
                    string usuario = form["username"].ToString();
                    //int estado = 1;

                    var usuarioLogueado = db.Usuario.Where(x => x.Correo == usuario && x.Contraseña == pwd /*&& x.usuarioEstatus == estado*/).FirstOrDefault();

                    if (usuarioLogueado != null)
                    {
                        setAuthIntra au = new setAuthIntra
                        (
                            HttpContext,
                            $"{usuarioLogueado.Nombre} {usuarioLogueado.Apellido}",
                            usuarioLogueado.idUsuario,
                            usuario,// Correo
                            pwd
                        );

                        entra = true;
                    }
                }

                if (entra)
                {
                    return RedirectToAction("index","publicaciones");
                    //return OpenSession();
                }
            }
            TempData["msjError"] = "Usuario ó Contraseña Incorrecta";
            return RedirectToAction("index", "Login");
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            if (Session["nombre"] != null)
                CloseSession();

            return RedirectToAction("index", "Login");
        }

        public void CloseSession()
        {
            //Elminamos informacion del usario de la cache.
            Session.Abandon();
            // Eliminamos el tikect de autenticacion 
            FormsAuthentication.SignOut();
            // Limpiamos la Cokkies
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);
        }
    }
}