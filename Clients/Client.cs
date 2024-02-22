using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;

namespace Company.Function.Clients;
public static class Client
{
    private static readonly string EndpointUri = "https://dt-cosmos-db.documents.azure.com:443/";
    private static readonly string PrimaryKey = "p7Z4rv7VfjJLTdC2m7zxCIdvXT0fqfeymH7S0YzJWmLdlBuds0It9yN5fK0vZ6FAyzFlrgLOz7egACDbVmzodQ==";

    public static CosmosClient CosmosSetupClientAsync()
    {
        // Create a new instance of the Cosmos Client
        var cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);

        return cosmosClient;
    }

    public static async Task<Database> CreateDatabaseAsync(CosmosClient cosmosClient, string databaseId)
    {
        // Create a new database using the cosmosClient
        return await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);
    }

    public static async Task<Container> CreateContainerAsync(Database database, string containerId, string partitionKey)
    {
        // Create a new container
        return await database.CreateContainerIfNotExistsAsync(containerId, partitionKey);
    }
}