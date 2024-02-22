
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Resolvers;
using Newtonsoft.Json.Serialization;

namespace Company.Function.DTOs;
[OpenApiExample(typeof(DTCreationDTOExample))]
public class DTCreationDTO
{
    [Newtonsoft.Json.JsonProperty("fullname", Required = Newtonsoft.Json.Required.Always)]
    public string Fullname { get; set; }
}

public class DTCreationDTOExample : OpenApiExample<DTCreationDTO>
{
    public override IOpenApiExample<DTCreationDTO> Build(NamingStrategy namingStrategy = null)
    {
        Examples.Add(
            OpenApiExampleResolver.Resolve(
                "DTCreationDTOExample",
                new DTCreationDTO()
                {
                    Fullname = "John Doe"
                },
                namingStrategy
            )
        );

        return this;
    }
}