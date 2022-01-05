using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
	public class DataContext : IdentityDbContext<AppUser>
    {
		public DataContext(DbContextOptions options) : base(options)
        {
        }

		public DbSet<MentorJobApplication> JobApplications { get; set; }
		public DbSet<Review> Reviews {get;set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUserCategory> AppUserCategories { get; set; }
        public DbSet<AppUserSkill> AppUserSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CategorySkill> CategorySkills { get; set; }
		public DbSet<Photo> Photos { get; set; }
		public DbSet<Mentorship> Mentorships { get; set; }
		public new DbSet<Role> Roles { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUserCategory>(x => x.HasKey(ac => new { ac.AppUserId, ac.CategoryId }));

            builder.Entity<AppUserCategory>()
                .HasOne(u => u.Mentor)
                .WithMany(c => c.Categories)
                .HasForeignKey(ac => ac.AppUserId);

            builder.Entity<AppUserCategory>()
                .HasOne(u => u.Category)
                .WithMany(c => c.Mentors)
                .HasForeignKey(ac => ac.CategoryId);

            builder.Entity<AppUserSkill>(x => x.HasKey(aus => new { aus.MentorId, aus.SkillId }));

            builder.Entity<AppUserSkill>()
                .HasOne(aus => aus.Mentor)
                .WithMany(c => c.Skills)
                .HasForeignKey(aus => aus.MentorId);

            builder.Entity<AppUserSkill>()
                .HasOne(aus => aus.Skill)
                .WithMany(s => s.Mentors)
                .HasForeignKey(aus => aus.SkillId);

            builder.Entity<Review>(b =>
            {
                b.HasKey(r => new{r.MentorId,r.ClientId});

                b.HasOne(r => r.Mentor)
                    .WithMany(cl => cl.ClientReviews)
                    .HasForeignKey(r => r.MentorId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(r => r.Client)
                    .WithMany(c => c.MentorReviews)
                    .HasForeignKey(r => r.ClientId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Mentorship>(b =>
            {
                b.HasKey(m => new { m.MentorId, m.ClientId });

                b.HasOne(m => m.Mentor)
                    .WithMany(m => m.Clients)
                    .HasForeignKey(m => m.MentorId); 

                b.HasOne(m => m.Client)
                    .WithMany(c => c.Mentors)
                    .HasForeignKey(m => m.ClientId);
            });

            builder.Entity<CategorySkill>(x => x.HasKey(cs => new { cs.SkillId , cs.CategoryId }));

            builder.Entity<CategorySkill>()
                .HasOne(cs => cs.Skill)
                .WithMany(s => s.Categories)
                .HasForeignKey(cs => cs.SkillId);

            builder.Entity<CategorySkill>()
                .HasOne(cs => cs.Category)
                .WithMany(c => c.Skills)
                .HasForeignKey(cs => cs.CategoryId);
        }
    }
}