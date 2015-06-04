using System.Web;
using System.Web.Optimization;

namespace PhotoStory {
	public class BundleConfig {
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles) {
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
			bundles.Add(new ScriptBundle("~/bundles/bootstrapjs")
				.Include("~/Scripts/bootstrap.min.js")
				.Include("~/Scripts/fileinput.min.js"));

			bundles.Add(new LessBundle("~/Content/less").Include("~/Content/layout.less"));
			bundles.Add(new StyleBundle("~/Content/bootstrapcss")
				.Include("~/Content/bootstrap.min.css")
				.Include("~/Content/bootstrap-fileinput/css/fileinput.min.css"));
		}
	}
}