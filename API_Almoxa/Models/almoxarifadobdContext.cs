using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_Almoxa.Models
{
    public partial class almoxarifadobdContext : DbContext
    {
        public almoxarifadobdContext()
        {
        }

        public almoxarifadobdContext(DbContextOptions<almoxarifadobdContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<EntradaEstoque> EntradaEstoques { get; set; } = null!;
        public virtual DbSet<Fornecedor> Fornecedors { get; set; } = null!;
        public virtual DbSet<Lote> Lotes { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<SaidaEstoque> SaidaEstoques { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PC03LAB2539\\SENAI; Database=almoxarifadobd; User Id=sa; Password=senai.123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240C54FE8ED9");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.NomeCategoria)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeCategoria");
            });

            modelBuilder.Entity<EntradaEstoque>(entity =>
            {
                entity.HasKey(e => e.IdEntrada)
                    .HasName("PK__EntradaE__19943CE0FCC3E58C");

                entity.ToTable("EntradaEstoque");

                entity.Property(e => e.IdEntrada).HasColumnName("idEntrada");

                entity.Property(e => e.DataEntrada)
                    .HasColumnType("date")
                    .HasColumnName("dataEntrada");

                entity.Property(e => e.IdFornecedor).HasColumnName("idFornecedor");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.QuantidadeEntrada).HasColumnName("quantidadeEntrada");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.EntradaEstoques)
                    .HasForeignKey(d => d.IdFornecedor)
                    .HasConstraintName("FK__EntradaEs__idFor__4316F928");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.EntradaEstoques)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__EntradaEs__idPro__4222D4EF");
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.HasKey(e => e.IdFornecedor)
                    .HasName("PK__Forneced__CBE1227CC37D1778");

                entity.ToTable("Fornecedor");

                entity.Property(e => e.IdFornecedor).HasColumnName("idFornecedor");

                entity.Property(e => e.ContatoFornecedor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contatoFornecedor");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.NomeFornecedor)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeFornecedor");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Fornecedors)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Fornecedo__idCat__38996AB5");
            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.HasKey(e => e.IdLote)
                    .HasName("PK__Lote__1B91FFCBBC16D5C0");

                entity.ToTable("Lote");

                entity.Property(e => e.IdLote).HasColumnName("idLote");

                entity.Property(e => e.DataValidade)
                    .HasColumnType("date")
                    .HasColumnName("dataValidade");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.Quantidade)
                    .HasColumnName("quantidade")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.ValorTotal)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valorTotal");

                entity.Property(e => e.ValorUnitario)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("valorUnitario");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Lotes)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Lote__idProduto__3F466844");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produto__5EEDF7C34E9CB415");

                entity.ToTable("Produto");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.IdFornecedor).HasColumnName("idFornecedor");

                entity.Property(e => e.NomeProduto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nomeProduto");

                entity.HasOne(d => d.IdFornecedorNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdFornecedor)
                    .HasConstraintName("FK__Produto__idForne__3B75D760");
            });

            modelBuilder.Entity<SaidaEstoque>(entity =>
            {
                entity.HasKey(e => e.IdSaida)
                    .HasName("PK__SaidaEst__86DFA3AE155D8C71");

                entity.ToTable("SaidaEstoque");

                entity.Property(e => e.IdSaida).HasColumnName("idSaida");

                entity.Property(e => e.DataSaida)
                    .HasColumnType("date")
                    .HasColumnName("dataSaida");

                entity.Property(e => e.IdProduto).HasColumnName("idProduto");

                entity.Property(e => e.QuantidadeSaida).HasColumnName("quantidadeSaida");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.SaidaEstoques)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__SaidaEsto__idPro__45F365D3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
