namespace RedSocial.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Amigos = new HashSet<Amigos>();
            publicaciones = new HashSet<publicaciones>();
        }

        [Key]
        public int idUsuario { get; set; }

        [StringLength(25)]
        public string Correo { get; set; }

        [StringLength(25)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Contraseña { get; set; }

        [StringLength(25)]
        public string Apellido { get; set; }

        [StringLength(20)]
        public string email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaDeNacimiento { get; set; }

        [StringLength(20)]
        public string URLfoto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Amigos> Amigos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<publicaciones> publicaciones { get; set; }
    }
}
