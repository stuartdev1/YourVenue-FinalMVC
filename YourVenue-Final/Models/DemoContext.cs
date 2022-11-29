using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace YourVenue_Final.Models
{
    public partial class DemoContext : DbContext
    {
        public DemoContext()
        {
        }

        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Host> Hosts { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=buscissql1901\\cisweb;Database=GellerDB;User ID=oracled;Password=apex;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Contact");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.AddressLine1).HasMaxLength(500);

                entity.Property(e => e.AddressLine2).HasMaxLength(15);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CustomerDOB).HasColumnType("date");

                entity.Property(e => e.CustomerFirstName).HasMaxLength(50);

                entity.Property(e => e.CustomerLastName).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.LastActivity)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastActivityUserID).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Zip).HasMaxLength(15);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventName).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerID)
                    .HasConstraintName("FK_Events_Customers");

                entity.HasOne(d => d.Venue)
                    .WithMany()
                    .HasForeignKey(d => d.VenueID)
                    .HasConstraintName("FK_Events_Venues");
            });

            modelBuilder.Entity<Host>(entity =>
            {
                entity.Property(e => e.HostAddressLine1).HasMaxLength(50);

                entity.Property(e => e.HostCity).HasMaxLength(50);

                entity.Property(e => e.HostEmail).HasMaxLength(50);

                entity.Property(e => e.HostFirstName).HasMaxLength(50);

                entity.Property(e => e.HostLastName).HasMaxLength(50);

                entity.Property(e => e.HostState).HasMaxLength(50);

                entity.Property(e => e.HostZip).HasMaxLength(15);

                entity.Property(e => e.LastActivity).HasColumnType("datetime");

                entity.Property(e => e.LastActivityUserID).HasMaxLength(50);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasIndex(e => e.MessageID, "IX_Messages");

                entity.Property(e => e.MessageBody).IsRequired();

                entity.Property(e => e.TimeSent).HasColumnType("datetime");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ReceiverID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceiverID");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.SenderID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SenderID");
            });

            modelBuilder.Entity<Venue>(entity =>
            {
                entity.Property(e => e.VenueAddress).HasMaxLength(50);

                entity.Property(e => e.VenueCity).HasMaxLength(50);

                entity.Property(e => e.VenueName).HasMaxLength(50);

                entity.Property(e => e.VenueState).HasMaxLength(50);

                entity.HasOne(d => d.VenueHost)
                    .WithMany(p => p.Venues)
                    .HasForeignKey(d => d.VenueHostID)
                    .HasConstraintName("FK_VenueHostID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
