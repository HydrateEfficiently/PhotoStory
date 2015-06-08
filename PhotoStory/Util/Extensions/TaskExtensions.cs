using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.Util.Extensions {

	public static class TaskExtensions {

		public async static Task WhenOne(Task task) {
			await Task.WhenAll(task);
		}

		public async static Task<T> WhenOne<T>(Task<T> task) {
			return (await Task.WhenAll(task))[0];
		}

	}
}
