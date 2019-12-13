namespace WApi_Server_Acosta.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelVentas : DbContext
    {
        public ModelVentas()
            : base("name=ModelVentas")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<DetallePedido> DetallePedido { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<DetallePedido>()
                .Property(e => e.precio)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DetallePedido>()
                .Property(e => e.subtotal)
                .HasPrecision(10, 2);

            modelBuilder.Entity<DetallePedido>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Pedido>()
                .Property(e => e.total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Pedido>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Pedido>()
                .HasMany(e => e.DetallePedido)
                .WithRequired(e => e.Pedido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.precio)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Producto>()
                .Property(e => e.imagen)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

           /* modelBuilder.Entity<Producto>()
                .HasMany(e => e.DetallePedido)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);*/

            modelBuilder.Entity<TipoUsuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoUsuario>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.TipoUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.foto)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombreusu)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Pedido)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
