using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ProductosAngelVillafan
{
    public partial class itesrcContext : DbContext
    {
        public itesrcContext()
        {
        }

        public itesrcContext(DbContextOptions<itesrcContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Seccion> Seccions { get; set; }
        public virtual DbSet<Vwcontcincopieza> Vwcontcincopiezas { get; set; }
        public virtual DbSet<Vwdepartamentosbynombre> Vwdepartamentosbynombres { get; set; }
        public virtual DbSet<Vwinfodptopiso> Vwinfodptopisos { get; set; }
        public virtual DbSet<Vwlistadoaspiradora> Vwlistadoaspiradoras { get; set; }
        public virtual DbSet<Vwlistadoprecioseconomico> Vwlistadoprecioseconomicos { get; set; }
        public virtual DbSet<Vwpresiomayoravg> Vwpresiomayoravgs { get; set; }
        public virtual DbSet<Vwproductosnolitro> Vwproductosnolitros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=itesrc", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.ToTable("departamento");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Sku)
                    .HasName("PRIMARY");

                entity.ToTable("producto");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.IdSeccion, "FK_producto_1");

                entity.Property(e => e.Sku).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Precio).HasPrecision(10, 2);

                entity.HasOne(d => d.IdSeccionNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdSeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkProductoSeccion");
            });

            modelBuilder.Entity<Seccion>(entity =>
            {
                entity.ToTable("seccion");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.IdDepartamento, "fkSeccionDepto_idx");

                entity.HasIndex(e => e.IdSeccionPrincipal, "kfSeccionPrincipal_idx");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Seccions)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("fkSeccionDepto");
            });

            modelBuilder.Entity<Vwcontcincopieza>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwcontcincopiezas");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(250)
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(300)
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Precio).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Vwdepartamentosbynombre>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwdepartamentosbynombre");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            modelBuilder.Entity<Vwinfodptopiso>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwinfodptopisos");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(250)
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(300)
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Precio).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Vwlistadoaspiradora>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwlistadoaspiradoras");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(250)
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(300)
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Precio).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Vwlistadoprecioseconomico>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwlistadoprecioseconomico");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(250)
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(300)
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Precio).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Vwpresiomayoravg>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwpresiomayoravg");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(250)
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(300)
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Precio).HasPrecision(10, 2);
            });

            modelBuilder.Entity<Vwproductosnolitro>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwproductosnolitro");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(250)
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(300)
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Precio).HasPrecision(10, 2);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
