using RedSocial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace RedSocial.Code
{
    public class setAuthIntra
    {
        public setAuthIntra(HttpContextBase httpContext, string usuario, int usuarioID, string mail, string clave)
        {
            string Roles = "";

            using (var db = new RedSocialDB())
            {
                // Obtener los roles vinculados al usuario que se está editando
                var RolesDelUsuario = (from t in db.RedSocial_RolesUsuarios
                                       join t2 in db.RedSocial_Roles
                                       on t.RolID equals t2.ID
                                       where t.UsuarioID == usuarioID
                                        && t.Estado // == true
                                        && t2.Estado // == true
                                       select t2.Nombre).ToArray();

                if (RolesDelUsuario != null)
                    Roles = string.Join("|", RolesDelUsuario);
            }

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                                               1,                                     // ticket version
                                               usuario,                               // authenticated username
                                               DateTime.Now,                          // issueDate
                                               DateTime.Now.AddMinutes(15),           // expiryDate
                                               true,                          // true to persist across browser sessions
                                               Roles,                              // can be used to store additional user data
                                               FormsAuthentication.FormsCookiePath);  // the path for the cookie

            string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            IIdentity identity = new GenericIdentity(ticket.Name);
            IPrincipal principal = new GenericPrincipal(identity, ticket.UserData.Split('|'));


            HttpContext.Current.User = principal;

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;

            httpContext.Session["nombre"] = usuario;
            httpContext.Session["correo"] = mail;
            httpContext.Session["clave"] = clave;
            httpContext.Session["Rol"] = Roles;
            httpContext.Session["UsuarioID"] = usuarioID;
            

            httpContext.Response.Cookies.Add(cookie);
        }
    }
}