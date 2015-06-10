using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.Data.Static {

	public static class RepositorySettings {

		public static Repository Instance { get; private set; }

		static RepositorySettings() {
			Instance = new LocalRepository();
		}
	}
}
