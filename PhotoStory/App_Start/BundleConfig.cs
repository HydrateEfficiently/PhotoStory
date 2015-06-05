using System.Web;
using System.Web.Optimization;

namespace PhotoStory {

	public class BundleConfig {
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles) {
			bundles.Add(new ScriptBundle("~/corejs")
				.Include("~/Scripts/jquery-{version}.js")
				.Include("~/Scripts/require.js")
				.Include("~/Scripts/bootstrap.min.js")
				.Include("~/Scripts/fileinput.min.js"));

			bundles.Add(new StyleBundle("~/corecss")
				.Include("~/Content/bootstrap.min.css")
				.Include("~/Content/bootstrap-fileinput/css/fileinput.min.css"));

			bundles.Add(new LessBundle("~/coreless")
				.Include("~/Content/layout.less"));
		}
	}
}