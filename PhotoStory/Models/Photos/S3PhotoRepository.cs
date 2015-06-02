using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStory.Models.Photos {

	public class S3PhotoRepository : PhotoRepository {

		private const string BucketName = "mdfw-photoblog-dev-1";
		private const string AccessKey = "AKIAICM6SKXHIFPATSBQ";
		private const string SecretKey = "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";

		private static readonly AWSCredentials Credentials = new BasicAWSCredentials(AccessKey, SecretKey);

		public async Task<bool> UploadAsync(Photo photo) {
			using (var photoStream = photo.GetStream())
			using (var client = new AmazonS3Client(Credentials, Amazon.RegionEndpoint.USEast1)) {
				var request = new PutObjectRequest() {
					BucketName = BucketName,
					Key = "Test",
					ContentType = photo.ContentType,
					InputStream = photoStream.Result
				};
				var response = await client.PutObjectAsync(request);
				return true;
			}
		}

		public bool Upload(Photo photo) {
			return UploadAsync(photo).Result;
		}
	}
}
