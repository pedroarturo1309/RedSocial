using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedSocial.Models.Roles
{
    public class RedSocial_Roles
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        public bool Estado { get; set; }

    }
}