using RedSocial.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace RedSocial.Controllers
{
    public class PublicacionesController : Controller
    {
        // GET: Publicaciones
        public ActionResult Index()
        {
            using (var db = new RedSocialDB())
            {
                var publicaciones = (from a in db.publicaciones
                                     select a).Include(a=>a.Usuario).ToList();

                return View(publicaciones);     
            }
                
        }
        //GET: Publicaciones
        public ActionResult Publicaciones()
        {
            return View();
        }
        
        [HttpPost, ValidateInput(false)]
        public ActionResult Publicaciones(publicaciones Publicaciones)
        {
            try
            {
                if (Publicaciones != null)
                {
                    using (var db = new RedSocialDB())
                    {
                        Publicaciones.Descripcion = HttpUtility.HtmlEncode(Publicaciones.Descripcion);
                        Publicaciones.idUsuario = int.Parse(Session["UsuarioID"].ToString());
                        db.publicaciones.Add(Publicaciones);
                        db.SaveChanges();
                    }
                }
                ViewBag.guardado = true;
                return View("Index");
            }
            catch (Exception e)
            {
                ViewBag.guardado = false;
                return View("index");
            }
        }
    }
}