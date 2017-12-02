namespace RedSocial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Amigos
    {
        [Key]
        public int idAmigos { get; set; }

        public int? idUsuarioYO { get; set; }

        public int? idUsuario { get; set; }
    }
}
