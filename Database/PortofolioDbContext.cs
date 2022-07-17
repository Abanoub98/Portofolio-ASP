using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Portofolio.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
#nullable disable

namespace Portofolio.Database
{
    public partial class PortofolioDbContext : IdentityDbContext<User, UserRole, int>
    {
        public PortofolioDbContext(DbContextOptions<PortofolioDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactStatus> ContactStatuses { get; set; }
        public virtual DbSet<LinkType> LinkTypes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectFeedback> ProjectFeedbacks { get; set; }
        public virtual DbSet<ProjectImage> ProjectImages { get; set; }
        public virtual DbSet<ProjectLink> ProjectLinks { get; set; }
        public virtual DbSet<ProjectType> ProjectTypes { get; set; }
        public virtual DbSet<UserLink> UserLinks { get; set; }
        public virtual DbSet<UserRoleInProject> UserProjectRoles { get; set; }
        public virtual DbSet<UsersInProject> UsersInProjects { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ProjectLog> ProjectLogs { get; set; }

        public virtual DbSet<UserCertificates> UsersCertificates { get; set; }

        public virtual DbSet<RequestedService> RequestedServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
