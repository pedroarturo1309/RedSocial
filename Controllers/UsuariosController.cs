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
        [AllowAnonymous]
        public ActionResult CrearUsuario()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public ActionResult CrearUsuario(Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    using (var db = new RedSocialDB())
                    {
                        usuario.Contraseña = Code.UtilityMethods.SetSHA1(usuario.Contraseña);
                        db.Usuario.Add(usuario);

                        var rolID = db.RedSocial_Roles.Where(a => a.Nombre.ToLower() == "general").FirstOrDefault().ID;

                        var Rol = new Models.Roles.RedSocial_RolesUsuarios
                        {
                            Estado = true,
                            UsuarioID = usuario.idUsuario,
                            RolID = rolID
                        };

                        db.RedSocial_RolesUsuarios.Add(Rol);

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