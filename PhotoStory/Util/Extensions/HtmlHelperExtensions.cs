using Newtonsoft.Json;
using System.Web;
using System.Web.Mvc;

namespace PhotoStory.Util.Extensions {

	public static class HtmlHelperExtensions {

		public static IHtmlString Serialize<T>(this HtmlHelper<T> helper, object obj) {
			return helper.Raw(JsonConvert.SerializeObject(obj));
		}

		public static IHtmlString Serialize(this HtmlHelper helper, object obj) {
			return helper.Raw(JsonConvert.SerializeObject(obj));
		}
	}
}
