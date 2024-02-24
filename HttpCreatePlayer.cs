using System;
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
public static class HttpCreatePlayer
{
    [FunctionName("HttpCreatePlayer")]
    public static async Task<IActionResult> HttpCreatePlayerRun(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("HttpCreatePlayer function processed a request.");

        string name = req.Query["name"];

        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var dto = JsonConvert.DeserializeObject<PlayerCreationDTO>(requestBody);

        if (
            dto != null &&
            !string.IsNullOrEmpty(dto.Fullname) &&
            dto.BasePrice >= 0 &&
            dto.Stars >= 1 &&
            dto.Stars <= 5)
        {
            var cosmosClient = Client.CosmosSetupClientAsync();
            var database = await Client.CreateDatabaseAsync(cosmosClient, "az-204-cosmos-dt");
            var container = await Client.CreateContainerAsync(database, "az-204-container-player", "/fullname");

            Player player = new Player(dto.Fullname, dto.BasePrice, dto.Stars);

            await container.CreateItemAsync(player);

            return new OkObjectResult(
                new GenericResponse<Player, string>
                {
                    Data = player,
                    Error = null
                }
            );
        }
        return new BadRequestObjectResult(
            new GenericResponse<string, string>
            {
                Data = null,
                Error = "Data of body request is not valid"
            }
        );
    }
}
