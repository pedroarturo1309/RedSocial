using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedSocial.Models.Roles
{
    public class RedSocial_RolesUsuarios
    {
        [Key]
        public int ID { get; set; }

        public int RolID { get; set; }

        public int UsuarioID { get; set; }

        public bool Estado { get; set; }

        public virtual RedSocial_Roles RedSocial_Roles { get; set; }
    }
}