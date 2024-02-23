az login

az group create --location <myLocation> --name az204-cosmos-rg

az cosmosdb create --name <myCosmosDBacct> --resource-group az204-cosmos-rg

```json
{
  "analyticalStorageConfiguration": {
    "schemaType": "Placeholder"
  },
  "apiProperties": null,
  "backupPolicy": {
    "migrationState": null,
    "periodicModeProperties": {
      "backupIntervalInMinutes": 240,
      "backupRetentionIntervalInHours": 8,
      "backupStorageRedundancy": "Placeholder"
    },
    "type": "Periodic"
  },
  "capabilities": [],
  "capacity": null,
  "connectorOffer": null,
  "consistencyPolicy": {
    "defaultConsistencyLevel": "Placeholder",
    "maxIntervalInSeconds": 5,
    "maxStalenessPrefix": 100
  },
  "cors": [],
  "createMode": null,
  "customerManagedKeyStatus": null,
  "databaseAccountOfferType": "Placeholder",
  "defaultIdentity": "Placeholder",
  "disableKeyBasedMetadataWriteAccess": false,
  "disableLocalAuth": false,
  "documentEndpoint": "https://placeholder.documents.azure.com:443/",
  "enableAnalyticalStorage": false,
  "enableAutomaticFailover": false,
  "enableBurstCapacity": false,
  "enableCassandraConnector": null,
  "enableFreeTier": false,
  "enableMultipleWriteLocations": false,
  "enablePartitionMerge": false,
  "failoverPolicies": [
    {
      "failoverPriority": 0,
      "id": "placeholder-eastus",
      "locationName": "Placeholder"
    }
  ],
  "id": "/subscriptions/placeholder/resourceGroups/placeholder/providers/Microsoft.DocumentDB/databaseAccounts/placeholder",
  "identity": {
    "principalId": null,
    "tenantId": null,
    "type": "None",
    "userAssignedIdentities": null
  },
  "instanceId": "placeholder-instance-id",
  "ipRules": [],
  "isVirtualNetworkFilterEnabled": false,
  "keyVaultKeyUri": null,
  "keysMetadata": {
    "primaryMasterKey": {
      "generationTime": "2024-02-22T00:00:00.000000+00:00"
    },
    "primaryReadonlyMasterKey": {
      "generationTime": "2024-02-22T00:00:00.000000+00:00"
    },
    "secondaryMasterKey": {
      "generationTime": "2024-02-22T00:00:00.000000+00:00"
    },
    "secondaryReadonlyMasterKey": {
      "generationTime": "2024-02-22T00:00:00.000000+00:00"
    }
  },
  "kind": "Placeholder",
  "location": "Placeholder",
  "locations": [
    {
      "documentEndpoint": "https://placeholder-eastus.documents.azure.com:443/",
      "failoverPriority": 0,
      "id": "placeholder-eastus",
      "isZoneRedundant": false,
      "locationName": "Placeholder",
      "provisioningState": "Succeeded"
    }
  ],
  "minimalTlsVersion": "Tls12",
  "name": "placeholder-cosmos-db",
  "networkAclBypass": "None",
  "networkAclBypassResourceIds": [],
  "privateEndpointConnections": null,
  "provisioningState": "Succeeded",
  "publicNetworkAccess": "Enabled",
  "readLocations": [
    {
      "documentEndpoint": "https://placeholder-eastus.documents.azure.com:443/",
      "failoverPriority": 0,
      "id": "placeholder-eastus",
      "isZoneRedundant": false,
      "locationName": "Placeholder",
      "provisioningState": "Succeeded"
    }
  ],
  "resourceGroup": "placeholder-resource-group",
  "restoreParameters": null,
  "systemData": {
    "createdAt": "2024-02-22T00:00:00.000000+00:00",
    "createdBy": null,
    "createdByType": null,
    "lastModifiedAt": null,
    "lastModifiedBy": null,
    "lastModifiedByType": null
  },
  "tags": {},
  "type": "Microsoft.DocumentDB/databaseAccounts",
  "virtualNetworkRules": [],
  "writeLocations": [
    {
      "documentEndpoint": "https://placeholder-eastus.documents.azure.com:443/",
      "failoverPriority": 0,
      "id": "placeholder-eastus",
      "isZoneRedundant": false,
      "locationName": "Placeholder",
      "provisioningState": "Succeeded"
    }
  ]
}
```

recuperar el document endpoint

```json
{
    // ...
    "documentEndpoint": "https://placeholder.documents.azure.com:443/",
    // ...
}
```

luego puedo listar todas las DBs con

az cosmosdb list

podemos dar detalle con el atributo query

az cosmosdb list --query "[].{de:documentEndpoint,rg:resourceGroup}"

<!-- Retrieve the primary key -->
az cosmosdb keys list --name <myCosmosDBacct> --resource-group az204-cosmos-rg

```json
{
  "primaryMasterKey": "PlaceholderPrimaryMasterKey",
  "primaryReadonlyMasterKey": "PlaceholderPrimaryReadonlyMasterKey",
  "secondaryMasterKey": "PlaceholderSecondaryMasterKey",
  "secondaryReadonlyMasterKey": "PlaceholderSecondaryReadonlyMasterKey"
}
```

dotnet add package Microsoft.Azure.Cosmos