using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ZayirApp.Data
{
    public partial class ZayirDbContext : DbContext
    {
        public ZayirDbContext()
        {
        }

        public ZayirDbContext(DbContextOptions<ZayirDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agreement> Agreement { get; set; }
        public virtual DbSet<Badge> Badge { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Gate> Gate { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }
        public virtual DbSet<VisitAgreement> VisitAgreement { get; set; }
        public virtual DbSet<Visitor> Visitor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ZayirDatabase;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Contact)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contact__Departm__276EDEB3");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.DeliveryContact)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Delivery__Contac__3A81B327");

                entity.HasOne(d => d.Registrar)
                    .WithMany(p => p.DeliveryRegistrar)
                    .HasForeignKey(d => d.RegistrarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Delivery__Regist__3C69FB99");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.Delivery)
                    .HasForeignKey(d => d.VisitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Delivery__Visito__3B75D760");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.VisitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Document__Visito__2E1BDC42");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Conta__4BAC3F29");

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.DeliveryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Deliv__4CA06362");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Visit__4D94879B");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.VisitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notificat__Visit__4E88ABD4");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__Conta__2A4B4B5E");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.Registration)
                    .HasForeignKey(d => d.VisitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Registrat__Visit__2B3F6F97");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.HasOne(d => d.Badge)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.BadgeId)
                    .HasConstraintName("FK__Visit__BadgeId__412EB0B6");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.VisitContact)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit__ContactId__4316F928");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK__Visit__EventId__403A8C7D");

                entity.HasOne(d => d.Gate)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.GateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit__GateId__3F466844");

                entity.HasOne(d => d.Registrar)
                    .WithMany(p => p.VisitRegistrar)
                    .HasForeignKey(d => d.RegistrarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit__Registrar__44FF419A");

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.RegistrationId)
                    .HasConstraintName("FK__Visit__Registrat__440B1D61");

                entity.HasOne(d => d.Visitor)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.VisitorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Visit__VisitorId__4222D4EF");
            });

            modelBuilder.Entity<VisitAgreement>(entity =>
            {
                entity.HasOne(d => d.Agreement)
                    .WithMany(p => p.VisitAgreement)
                    .HasForeignKey(d => d.AgreementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VisitAgre__Agree__47DBAE45");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.VisitAgreement)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VisitAgre__Visit__48CFD27E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
