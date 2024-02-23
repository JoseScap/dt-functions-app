using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Company.Function.DTOs;
using Company.Function.Clients;
using Company.Function.Entities;

namespace Company.Function;
public static class HttpCreateDT
{
    [FunctionName("HttpCreateDT")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("HttpCreateDT function processed a request.");

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var dto = JsonConvert.DeserializeObject<DTCreationDTO>(requestBody);

        if (dto != null && !string.IsNullOrEmpty(dto.Fullname))
        {
            var cosmosClient = Client.CosmosSetupClientAsync();
            var database = await Client.CreateDatabaseAsync(cosmosClient, "az-204-cosmos-dt");
            var container = await Client.CreateContainerAsync(database, "az-204-container-dt", "/fullname");

            DT dt = new DT(dto.Fullname);

            await container.CreateItemAsync(dt);

            return new OkObjectResult(
                new GenericResponse<DT, string>
                {
                    Data = dt,
                    Error = null
                }
            );
        }
        else
        {
            return new BadRequestObjectResult(
                new GenericResponse<string, string>
                {
                    Data = null,
                    Error = "Data of body request is not valid"
                }
            );
        }
    }
}
