using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace PhotoStory.Controllers {

	public static class ApiHelper {

		public static TResult GetApiCallResult<TResult>(Func<Task<IHttpActionResult>> apiFuncCall) {
			Task<IHttpActionResult> task = apiFuncCall();
			task.Wait();
			var result = (CreatedAtRouteNegotiatedContentResult<TResult>)(task.Result);
			return result.Content;
		}
	}
}