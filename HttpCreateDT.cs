using System.IO;
using System.Net;
using System.Threading.Tasks;
using Company.Function.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Company.Function
{
    public class HttpCreateDT
    {
        private readonly ILogger<HttpCreateDT> _logger;

        public HttpCreateDT(ILogger<HttpCreateDT> log)
        {
            _logger = log;
        }

        [FunctionName("HttpCreateDT")]
        [OpenApiOperation(operationId: "CreateDT", tags: new[] { "Create DT" })]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(DTCreationDTO), Description = "DTCreationDTO", Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(DTCreationDTO), Description = "The OK response")]
        public async Task<IActionResult> CreateDT(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
            HttpRequest req)
        {
            _logger.LogInformation("HttpCreateDT function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var dto = JsonConvert.DeserializeObject<DTCreationDTO>(requestBody);

            return new OkObjectResult(dto);
        }
    }
}

