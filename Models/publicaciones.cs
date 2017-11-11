namespace RedSocial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class publicaciones
    {
        [Key]
        public int idPubli { get; set; }

        public int? idUsuario { get; set; }

        public string Descripcion { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
