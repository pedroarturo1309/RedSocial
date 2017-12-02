using RedSocial.Models;
using System;
using System.Collections.Generic;
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
                                     select a).ToList();


                return View(publicaciones);     
            }
                
        }
        //GET: Publicaciones
        public ActionResult Publicaciones()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Publicaciones(publicaciones Publicaciones)
        {
            try
            {
                if (Publicaciones != null)
                {
                    using (var db = new RedSocialDB())
                    {
                        db.publicaciones.Add(Publicaciones);
                        db.SaveChanges();
                    }
                }
                ViewBag.guardado = true;
                return View();
            }
            catch (Exception e)
            {
                ViewBag.guardado = false;
                return View();
            }
        }
    }
}