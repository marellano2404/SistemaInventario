using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Almacen.Core.Models
{
    public partial class InventarioDbContext : DbContext
    {
        public InventarioDbContext()
        {
        }

        public InventarioDbContext(DbContextOptions<InventarioDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Almacen> Almacen { get; set; }
        public virtual DbSet<Archivos> Archivos { get; set; }
        public virtual DbSet<ArticuloPropiedades> ArticuloPropiedades { get; set; }
        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<DetalleSalidaAlmacen> DetalleSalidaAlmacen { get; set; }
        public virtual DbSet<DetalleSalidaFarmacia> DetalleSalidaFarmacia { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Farmacias> Farmacias { get; set; }
        public virtual DbSet<Funcionalidades> Funcionalidades { get; set; }
        public virtual DbSet<HistorialUsuarios> HistorialUsuarios { get; set; }
        public virtual DbSet<InventarioAlmacen> InventarioAlmacen { get; set; }
        public virtual DbSet<Municipios> Municipios { get; set; }
        public virtual DbSet<OrganismoDonador> OrganismoDonador { get; set; }
        public virtual DbSet<Periodo> Periodo { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<ResguardoFarmacia> ResguardoFarmacia { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesFuncionalidades> RolesFuncionalidades { get; set; }
        public virtual DbSet<SalidasAlmacen> SalidasAlmacen { get; set; }
        public virtual DbSet<SalidasFarmacia> SalidasFarmacia { get; set; }
        public virtual DbSet<TipoArticulos> TipoArticulos { get; set; }
        public virtual DbSet<TipoFarmacia> TipoFarmacia { get; set; }
        public virtual DbSet<TipoGastos> TipoGastos { get; set; }
        public virtual DbSet<TipoServicios> TipoServicios { get; set; }
        public virtual DbSet<TipoUnidades> TipoUnidades { get; set; }
        public virtual DbSet<Transferencias> Transferencias { get; set; }
        public virtual DbSet<Ubicaciones> Ubicaciones { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<VEmpresaView> VEmpresaView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Helpers.ContextConfiguration.ConexionString, builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.HasOne(d => d.IdGerenteNavigation)
                    .WithMany(p => p.Almacen)
                    .HasForeignKey(x => x.IdGerente)
                    .HasConstraintName("FK_Establecimiento_Usuarios");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.Almacen)
                    .HasForeignKey(x => x.IdMunicipio)
                    .HasConstraintName("FK_Establecimiento_Municipios");

                entity.HasOne(d => d.IdPadreNavigation)
                    .WithMany(p => p.InverseIdPadreNavigation)
                    .HasForeignKey(x => x.IdPadre)
                    .HasConstraintName("FK_Establecimiento_Establecimiento");

                entity.HasOne(d => d.TipoEstablecimientoNavigation)
                    .WithMany(p => p.Almacen)
                    .HasForeignKey(x => x.TipoEstablecimiento)
                    .HasConstraintName("FK_Establecimiento_TipoEstablecimiento");
            });

            modelBuilder.Entity<Archivos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NombreArchivo).IsFixedLength();

                entity.Property(e => e.RutaImagen).IsUnicode(false);

                entity.Property(e => e.TipoArchivo).IsFixedLength();
            });

            modelBuilder.Entity<ArticuloPropiedades>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Articulos>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ClaveProducto).IsUnicode(false);

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Detalles).IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Presentacion).IsUnicode(false);

                entity.Property(e => e.TipoMedicamento).IsUnicode(false);
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Correo).IsUnicode(false);

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<DetalleSalidaAlmacen>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DetalleSalidaFarmacia>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ApellidoMaterno).IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno).IsUnicode(false);

                entity.Property(e => e.CodigoPuesto).IsFixedLength();

                entity.Property(e => e.Nombres).IsUnicode(false);

                entity.Property(e => e.Rfc).IsUnicode(false);

                entity.Property(e => e.Servicio).IsUnicode(false);

                entity.Property(e => e.Turno).IsFixedLength();
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Propietario).IsUnicode(false);

                entity.Property(e => e.Rfc).IsFixedLength();

                entity.Property(e => e.Slogan).IsUnicode(false);

                entity.HasOne(d => d.IdLogoNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(x => x.IdLogo)
                    .HasConstraintName("FK_Empresa_Archivos");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(x => x.IdMunicipio)
                    .HasConstraintName("FK_Empresa_Municipios");
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Clave).IsFixedLength();

                entity.Property(e => e.Numero).IsFixedLength();
            });

            modelBuilder.Entity<Farmacias>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Funcionalidades>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<HistorialUsuarios>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Describe).IsUnicode(false);

                entity.Property(e => e.Entradas).HasDefaultValueSql("((0))");

                entity.Property(e => e.FechaHora).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Validado).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<InventarioAlmacen>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.FechaAlta).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.InventarioAlmacen)
                    .HasForeignKey(x => x.IdArticulo)
                    .HasConstraintName("FK_Inventario_Articulos");

                entity.HasOne(d => d.IdResponsableNavigation)
                    .WithMany(p => p.InventarioAlmacen)
                    .HasForeignKey(x => x.IdResponsable)
                    .HasConstraintName("FK_Inventario_Usuarios");

                entity.HasOne(d => d.TipoUnidadNavigation)
                    .WithMany(p => p.InventarioAlmacen)
                    .HasForeignKey(x => x.TipoUnidad)
                    .HasConstraintName("FK_Inventario_TipoUnidades");
            });

            modelBuilder.Entity<Municipios>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Municipio).IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(x => x.IdEstado)
                    .HasConstraintName("FK_Municipios_Estados");
            });

            modelBuilder.Entity<OrganismoDonador>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Periodo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(x => x.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permisos_Roles");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(x => x.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permisos_Usuarios");
            });

            modelBuilder.Entity<ResguardoFarmacia>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<RolesFuncionalidades>(entity =>
            {
                entity.HasOne(d => d.IdFuncionalidadNavigation)
                    .WithMany(p => p.RolesFuncionalidades)
                    .HasForeignKey(x => x.IdFuncionalidad)
                    .HasConstraintName("FK_RolesFuncionalidades_Funcionalidades");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolesFuncionalidades)
                    .HasForeignKey(x => x.IdRol)
                    .HasConstraintName("FK_RolesFuncionalidades_Roles");
            });

            modelBuilder.Entity<SalidasAlmacen>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<SalidasFarmacia>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TipoFarmacia>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TipoGastos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TipoServicios>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);
            });

            modelBuilder.Entity<TipoUnidades>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Ubicaciones>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<VEmpresaView>(entity =>
            {
                entity.ToView("vEmpresaView");

                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Municipio).IsUnicode(false);

                entity.Property(e => e.NombreArchivo).IsFixedLength();

                entity.Property(e => e.Propietario).IsUnicode(false);

                entity.Property(e => e.Rfc).IsFixedLength();

                entity.Property(e => e.RutaImagen).IsUnicode(false);

                entity.Property(e => e.Slogan).IsUnicode(false);

                entity.Property(e => e.TipoArchivo).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
