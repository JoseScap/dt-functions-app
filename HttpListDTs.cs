using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Company.Function.Clients;
using Company.Function.Entities;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using Company.Function.DTOs;

namespace Company.Function
{
    public static class HttpListDTs
    {
        [FunctionName("HttpListDTs")]
        public static async Task<IActionResult> HttpListDTsRun(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("HttpCreateDT function processed a request.");

            try
            {
                var cosmosClient = Client.CosmosSetupClientAsync();
                var database = await Client.CreateDatabaseAsync(cosmosClient, "az-204-cosmos-dt");
                var container = await Client.CreateContainerAsync(database, "az-204-container-dt", "/fullname");

                var query = new QueryDefinition(
                    query: "SELECT * FROM dts"
                );

                var task = Task.Run(() => container.GetItemQueryIterator<DT>(
                    queryDefinition: query
                ));

                var queryResult = await task;

                List<DT> dtList = new List<DT>();

                while (queryResult.HasMoreResults)
                {
                    FeedResponse<DT> response = await queryResult.ReadNextAsync();

                    foreach (DT item in response)
                    {
                        dtList.Add(item);
                    }
                }

                return new OkObjectResult(
                    new GenericResponse<List<DT>, string>
                    {
                        Data = dtList,
                        Error = null
                    }
                );
            }
            catch
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
}
