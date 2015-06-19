using PhotoStory.Models.Entity.Accounts;
using PhotoStory.Models.Entity.Chapters;
using PhotoStory.Models.Entity.Photos;
using PhotoStory.Models.Entity.Stories;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PhotoStory.Models.Entity {

	public class PhotoStoryContext : DbContext {

		public PhotoStoryContext() : base("DefaultConnection") { }

		public DbSet<User> Users { get; set; }

		public DbSet<Photo> Photos { get; set; }

		public DbSet<Story> Stories { get; set; }

		public DbSet<Chapter> Chapters { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

	}
}
