using RedSocial.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RedSocial.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            ViewBag.guardado = "";
            return View();
        }

        //GET: CREAR USUARIO
        public ActionResult CrearUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearUsuario(Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    using (var db = new RedSocialDB())
                    {
                        db.Usuario.Add(usuario);
                        db.SaveChanges();
                    }
                }
                ViewBag.guardado = true;
                return View(usuario);
            }
            catch(Exception e)
            {
                ViewBag.guardado = false;
                return View(usuario);
            }
        }
    }
}