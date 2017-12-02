namespace RedSocial.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RedSocialDB : DbContext
    {
        public RedSocialDB()
            : base("name=RedSocialDB")
        {
        }

        public virtual DbSet<Amigos> Amigos { get; set; }
        public virtual DbSet<publicaciones> publicaciones { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Roles.RedSocial_Roles> RedSocial_Roles { get; set; }
        public virtual DbSet<Roles.RedSocial_RolesUsuarios> RedSocial_RolesUsuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<publicaciones>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Contraseña)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.URLfoto)
                .IsUnicode(false);
        }
    }
}
