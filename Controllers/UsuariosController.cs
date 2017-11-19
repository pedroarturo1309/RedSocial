using RedSocial.Models;
using System;
using System.Collections.Generic;
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
            if (usuario != null)
            {
                using (var db = new RedSocialDB())
                {
                    db.Usuario.Add(usuario);
                }
            }
            return View();
        }
    }
}