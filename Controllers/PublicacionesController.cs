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

        public JsonResult MeGusta(int idPublicacion)
        {

            try
            {
                using (var db = new RedSocialDB())
                {
                    var usuarioId = int.Parse(Session["UsuarioID"].ToString());
                    var ExisteMegusta = (from a in db.MeGusta
                                         where a.idPubli == idPublicacion && a.idUsuario == usuarioId
                                         select a).FirstOrDefault();

                    if (ExisteMegusta == null)
                    {
                        ExisteMegusta = new megusta
                        {
                            Estado = true,
                            FechaMegusta = DateTime.Now,
                            idPubli = idPublicacion,
                            idUsuario = usuarioId
                        };
                    }

                }
            }
            catch { }
            return Json("");

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
                return RedirectToAction("Index", "Publicaciones");
            }
            catch (Exception e)
            {
                ViewBag.guardado = false;
                return RedirectToAction("Index", "Publicaciones");
            }
        }
    }
}