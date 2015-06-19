using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using PhotoStory.Models.Public.Photos;
using System.Threading.Tasks;

namespace PhotoStory.Data.Static {

	public class S3Repository : Repository {

		private const string BucketName = "mdfw-photoblog-dev-1";
		private const string AccessKey = "AKIAICM6SKXHIFPATSBQ";
		private const string SecretKey = "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";

		private static readonly AWSCredentials Credentials = new BasicAWSCredentials(AccessKey, SecretKey);

		public async Task UploadAsync(Photo photo) {
			//await Task.WhenAll(new Task(() => {
			//	using (var photoStream = photo.GetStreamAsync())
			//	using (var client = new AmazonS3Client(Credentials, Amazon.RegionEndpoint.USEast1)) {
			//		var request = new PutObjectRequest() {
			//			BucketName = BucketName,
			//			Key = "Test",
			//			ContentType = photo.ContentType,
			//			InputStream = photoStream.Result
			//		};
			//		var response = await client.PutObjectAsync(request);
			//	}
			//}));
		}


		public Task<bool> DeleteAsync(Photo photo) {
			throw new System.NotImplementedException();
		}
	}
}
