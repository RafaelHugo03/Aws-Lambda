using System.Text.Json;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Api.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("Lambda")]
    public class LambdaController : Controller
    {
        private readonly IAmazonLambda AWSClient;
        
        public LambdaController()
        {
            AWSClient = AwsBuilder.CreateAWSClient();
        }
        [HttpPost("CallFunction")]
        public async Task<IActionResult> CallFunction([FromBody] LambdaRequest request)
        {
            var payload = JsonSerializer.Serialize(request);

            var invokeRequest = new InvokeRequest
            {
                FunctionName = "lambda-api",
                Payload = payload
            };

            try
            {
                var response = await AWSClient.InvokeAsync(invokeRequest);
                var result = System.Text.Encoding.UTF8.GetString(response.Payload.ToArray());
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

    public record LambdaRequest(DateTime? startDate, DateTime? endDate);
}