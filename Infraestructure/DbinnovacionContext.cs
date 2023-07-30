using System;
using System.Collections.Generic;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;

public partial class DbinnovacionContext : DbContext
{
    public DbinnovacionContext()
    {
    }

    public DbinnovacionContext(DbContextOptions<DbinnovacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Comercio> Comercios { get; set; }

    public virtual DbSet<Credito> Creditos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=mssql-co-nop-ingenieria.database.windows.net;Database=dbinnovacion;User Id=dbadmin;Password=m6RdBPgfN)9GTF{2;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__CLIENTE__885457EEBF2E0CC4");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("idCliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Cupo)
                .HasDefaultValueSql("((50000))")
                .HasColumnName("cupo");
            entity.Property(e => e.Deuda).HasColumnName("deuda");
            entity.Property(e => e.Direccion)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Comercio>(entity =>
        {
            entity.HasKey(e => e.IdComercio).HasName("PK__COMERCIO__F334A3FCDC25BACF");

            entity.ToTable("COMERCIO");

            entity.Property(e => e.IdComercio)
                .ValueGeneratedNever()
                .HasColumnName("idComercio");
            entity.Property(e => e.Direccion)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Credito>(entity =>
        {
            entity.HasKey(e => e.IdCredito).HasName("PK__CREDITO__1B07C6BB9B65C34B");

            entity.ToTable("CREDITO");

            entity.Property(e => e.IdCredito).HasColumnName("idCredito");
            entity.Property(e => e.FechaApro)
                .HasColumnType("date")
                .HasColumnName("fechaApro");
            entity.Property(e => e.FechaCierre)
                .HasColumnType("date")
                .HasColumnName("fechaCierre");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdComercio).HasColumnName("idComercio");
            entity.Property(e => e.Monto).HasColumnName("monto");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Creditos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__CREDITO__idClien__6383C8BA");

            entity.HasOne(d => d.IdComercioNavigation).WithMany(p => p.Creditos)
                .HasForeignKey(d => d.IdComercio)
                .HasConstraintName("FK__CREDITO__idComer__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
