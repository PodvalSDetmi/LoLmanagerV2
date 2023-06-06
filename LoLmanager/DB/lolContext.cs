using System;
using System.Collections.Generic;
using LoLmanager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LoLmanager.DB
{
    public partial class lolContext : DbContext
    {
        private static lolContext instance;

        public lolContext()
        {
        }

        public lolContext(DbContextOptions<lolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Build> Builds { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Difficult> Difficults { get; set; } = null!;
        public virtual DbSet<Hero> Heroes { get; set; } = null!;
        public virtual DbSet<MainRune> MainRunes { get; set; } = null!;
        public virtual DbSet<Passive1> Passive1s { get; set; } = null!;
        public virtual DbSet<Passive2> Passive2s { get; set; } = null!;
        public virtual DbSet<Passive3> Passive3s { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SubRune1> SubRune1s { get; set; } = null!;
        public virtual DbSet<SubRune2> SubRune2s { get; set; } = null!;
        public virtual DbSet<SubRune3> SubRune3s { get; set; } = null!;
        public virtual DbSet<SummonerSpell1> SummonerSpell1s { get; set; } = null!;
        public virtual DbSet<SummonerSpell2> SummonerSpell2s { get; set; } = null!;
        public virtual DbSet<TypeDamage> TypeDamages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=lol;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Build>(entity =>
            {
                entity.ToTable("Build");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdHero).HasColumnName("ID_Hero");

                entity.Property(e => e.IdMainRune).HasColumnName("ID_MainRune");

                entity.Property(e => e.IdMainSubRune1).HasColumnName("ID_MainSubRune1");

                entity.Property(e => e.IdMainSubRune2).HasColumnName("ID_MainSubRune2");

                entity.Property(e => e.IdMainSubRune3).HasColumnName("ID_MainSubRune3");

                entity.Property(e => e.IdPassive1).HasColumnName("ID_Passive1");

                entity.Property(e => e.IdPassive2).HasColumnName("ID_Passive2");

                entity.Property(e => e.IdPassive3).HasColumnName("ID_Passive3");

                entity.Property(e => e.IdSudeSubRune1).HasColumnName("ID_SudeSubRune1");

                entity.Property(e => e.IdSudeSubRune2).HasColumnName("ID_SudeSubRune2");

                entity.Property(e => e.IdSudeSubRune3).HasColumnName("ID_SudeSubRune3");

                entity.Property(e => e.IdSummonerSpell1).HasColumnName("ID_Summoner_Spell1");

                entity.Property(e => e.IdSummonerSpell2).HasColumnName("ID_Summoner_Spell2");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.IdHeroNavigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdHero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Build_Hero");

                entity.HasOne(d => d.IdMainRuneNavigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdMainRune)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Build_MainRune");

                entity.HasOne(d => d.IdMainSubRune1Navigation)
                    .WithMany(p => p.BuildIdMainSubRune1Navigations)
                    .HasForeignKey(d => d.IdMainSubRune1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Build_SubRune1");

                entity.HasOne(d => d.IdMainSubRune2Navigation)
                    .WithMany(p => p.BuildIdMainSubRune2Navigations)
                    .HasForeignKey(d => d.IdMainSubRune2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Build_SubRune2");

                entity.HasOne(d => d.IdMainSubRune3Navigation)
                    .WithMany(p => p.BuildIdMainSubRune3Navigations)
                    .HasForeignKey(d => d.IdMainSubRune3)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Build_SubRune3");

                entity.HasOne(d => d.IdPassive1Navigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdPassive1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Build_Passive1");

                entity.HasOne(d => d.IdPassive2Navigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdPassive2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Build_Passive2");

                entity.HasOne(d => d.IdPassive3Navigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdPassive3)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Build_Passive3");

                entity.HasOne(d => d.IdSudeSubRune1Navigation)
                    .WithMany(p => p.BuildIdSudeSubRune1Navigations)
                    .HasForeignKey(d => d.IdSudeSubRune1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Build_SubRune11");

                entity.HasOne(d => d.IdSudeSubRune2Navigation)
                    .WithMany(p => p.BuildIdSudeSubRune2Navigations)
                    .HasForeignKey(d => d.IdSudeSubRune2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Build_SubRune21");

                entity.HasOne(d => d.IdSudeSubRune3Navigation)
                    .WithMany(p => p.BuildIdSudeSubRune3Navigations)
                    .HasForeignKey(d => d.IdSudeSubRune3)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Build_SubRune31");

                entity.HasOne(d => d.IdSummonerSpell1Navigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdSummonerSpell1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Build_Summoner_Spell1");

                entity.HasOne(d => d.IdSummonerSpell2Navigation)
                    .WithMany(p => p.Builds)
                    .HasForeignKey(d => d.IdSummonerSpell2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Build_Summoner_Spell2");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Difficult>(entity =>
            {
                entity.ToTable("Difficult");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Hero>(entity =>
            {
                entity.ToTable("Hero");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdClass).HasColumnName("ID_Class");

                entity.Property(e => e.IdDifficult).HasColumnName("ID_Difficult");

                entity.Property(e => e.IdRole).HasColumnName("ID_Role");

                entity.Property(e => e.IdTypeDamage).HasColumnName("ID_TypeDamage");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.Heroes)
                    .HasForeignKey(d => d.IdClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hero_Class");

                entity.HasOne(d => d.IdDifficultNavigation)
                    .WithMany(p => p.Heroes)
                    .HasForeignKey(d => d.IdDifficult)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hero_Difficult");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Heroes)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hero_Role");

                entity.HasOne(d => d.IdTypeDamageNavigation)
                    .WithMany(p => p.Heroes)
                    .HasForeignKey(d => d.IdTypeDamage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hero_TypeDamage");
            });

            modelBuilder.Entity<MainRune>(entity =>
            {
                entity.ToTable("MainRune");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Passive1>(entity =>
            {
                entity.ToTable("Passive1");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Passive2>(entity =>
            {
                entity.ToTable("Passive2");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Passive3>(entity =>
            {
                entity.ToTable("Passive3");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SubRune1>(entity =>
            {
                entity.ToTable("SubRune1");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SubRune2>(entity =>
            {
                entity.ToTable("SubRune2");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SubRune3>(entity =>
            {
                entity.ToTable("SubRune3");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SummonerSpell1>(entity =>
            {
                entity.ToTable("Summoner_Spell1");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<SummonerSpell2>(entity =>
            {
                entity.ToTable("Summoner_Spell2");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TypeDamage>(entity =>
            {
                entity.ToTable("TypeDamage");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public static lolContext GetInstance()
        {
            if(instance == null)
            {
                instance = new lolContext();
            }
            return instance;
        }
    }
}
