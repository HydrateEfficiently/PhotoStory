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

		public static Task ContinueWithOrRollback(this Task task, Action<Task> continuationAction, Action<Task> rollbackAction) {
			Task nextTask = task.ContinueWith(continuationAction, TaskContinuationOptions.OnlyOnRanToCompletion);
			nextTask.ContinueWith(rollbackAction, TaskContinuationOptions.OnlyOnFaulted);
			return nextTask;
		}

		public static Task<T> ContinueWithOrRollback<T>(this Task<T> task, Func<Task, T> continuationFunc, Action<Task<T>> rollbackAction) {
			Task<T> nextTask = task.ContinueWith<T>(continuationFunc, TaskContinuationOptions.OnlyOnRanToCompletion);
			nextTask.ContinueWith(rollbackAction, TaskContinuationOptions.OnlyOnFaulted);
			return nextTask;
		}

		public static Task ContinueWithOrRollback<T>(this Task<T> task, Action<Task<T>> continuationAction, Action<Task> rollbackAction) {
			Task nextTask = task.ContinueWith(continuationAction, TaskContinuationOptions.OnlyOnRanToCompletion);
			nextTask.ContinueWith(rollbackAction, TaskContinuationOptions.OnlyOnFaulted);
			return nextTask;
		}

	}
}
