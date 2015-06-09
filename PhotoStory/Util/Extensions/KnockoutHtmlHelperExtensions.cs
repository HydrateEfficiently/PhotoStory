using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq;

namespace PhotoStory.Util.Extensions {

	public static class KnockoutHtmlHelperExtensions {

		public static MvcHtmlString DataBoundTextAreaFor<TModel, TProperty>(
			this HtmlHelper<TModel> helper,
			Expression<Func<TModel, TProperty>> expression,
			string dataBindValue,
			object htmlAttributes = null) {

			return helper.TextAreaFor(expression, GetHtmlAttributesWithDataBind(htmlAttributes, dataBindValue));
		}

		private static Dictionary<string, string> GetHtmlAttributesWithDataBind(object htmlAttributes, string dataBindValue) {
			Dictionary<string, string> result = htmlAttributes == null ?
				new Dictionary<string, string>() :
				htmlAttributes.GetType().GetProperties()
					.ToDictionary(x => x.Name, x => x.GetValue(htmlAttributes, null).ToString());
			result.Add("data-bind", dataBindValue);
			return result;
		}
	}
}