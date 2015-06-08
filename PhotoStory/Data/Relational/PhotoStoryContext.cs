using PhotoStory.Data.Relational.Entities.Photos;
using PhotoStory.Data.Relational.Entities.Account;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoStory.Data.Relational.Entities.Stories;

namespace PhotoStory.Data.Relational {

	public class PhotoStoryContext : DbContext {

		public PhotoStoryContext() : base("DefaultConnection") { }

		public DbSet<User> Users { get; set; }

		public DbSet<Photo> Photos { get; set; }

		public DbSet<Story> Stories { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

	}
}
