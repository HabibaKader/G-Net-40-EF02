using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Assignment02_EntityFrameworkCore.Classes;
using Microsoft.EntityFrameworkCore;

namespace Assignment02_EntityFrameworkCore
{
    public class AppDbContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> Profiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=.;Database=EventHubDB;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Event Configuration (Fluent API)
            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.LastModified)
                      .HasDefaultValueSql("GETDATE()");
            });

            // Attendee Configuration (Owned Address)
            modelBuilder.Entity<Attendee>()
                .OwnsOne(a => a.Address);

            // Registration (Composite Key)
            modelBuilder.Entity<Registration>()
                .HasKey(r => new { r.AttendeeId, r.EventId });

            modelBuilder.Entity<Registration>()
                .Property(r => r.RegisteredAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
