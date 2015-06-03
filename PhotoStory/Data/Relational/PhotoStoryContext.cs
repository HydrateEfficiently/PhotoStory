using PhotoStory.Data.Relational.Entities.Photo;
using PhotoStory.Data.Relational.Entities.Account;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.Data.Relational {

	public class PhotoStoryContext : DbContext {

		public PhotoStoryContext() : base("DefaultConnection") { }

		public DbSet<User> Users { get; set; }

		public DbSet<Photo> Photos { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}

	}
}
