using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AmazonController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AmazonController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get(string key)
        {
            var bucketName = _configuration["AWS_BucketName"]; 
            RegionEndpoint bucketRegion = Amazon.RegionEndpoint.EUNorth1;
            var AccessKey = _configuration["AWS_AccessKey"];
            var SecretKey = _configuration["AWS_SecretKey"]; 
            var client = new AmazonS3Client(AccessKey, SecretKey,bucketRegion);

            GetPreSignedUrlRequest preSignedUrlRequest = new  GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = key,
                Expires = DateTime.UtcNow.AddMinutes(1)
            };

            string preSignedUrl = await client.GetPreSignedURLAsync(preSignedUrlRequest);

            return Ok(preSignedUrl);
        }
    }
}