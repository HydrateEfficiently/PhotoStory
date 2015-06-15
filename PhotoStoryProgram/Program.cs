using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoStoryProgram {

	class Program {

		static void Main(string[] args) {
			int i = 0;

			Task outerTask = new Task(() => {
				Thread.Sleep(1000);
				i++;
			});
			outerTask.Start();

			var innerTask2 = outerTask
				.ContinueWithOrRollback(
					t => {
						Thread.Sleep(1000);
						throw new Exception();
					},
					t => {
						Thread.Sleep(1000);
						i--;
					})
				.ContinueWithOrRollback(
					t => {
						i++;
					},
					t => {
						throw new Exception("Test innerTask2");
					});

			innerTask2.Wait();
		}
	}

	public static class TaskExtensions {

		public static Task ContinueWithOrRollback(this Task task, Action<Task> continuationAction, Action<Task> rollbackAction) {
			Task nextTask = task.ContinueWith(continuationAction, TaskContinuationOptions.OnlyOnRanToCompletion);
			nextTask.ContinueWith(rollbackAction, TaskContinuationOptions.OnlyOnFaulted);
			return nextTask;
		}

	}

}
