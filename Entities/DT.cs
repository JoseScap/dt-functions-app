
using System;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Resolvers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Company.Function.Entities;
[OpenApiExample(typeof(DTExample))]
public class DT
{
    [JsonProperty(PropertyName = "id")]
    public string id { get; set; }
    [JsonProperty(PropertyName = "fullname")]
    public string fullname { get; set; }
    [JsonProperty(PropertyName = "money")]
    public double money { get; set; }

    public DT() { }
    public DT(string Fullname)
    {
        id = Guid.NewGuid().ToString();
        fullname = Fullname;
        money = 0;
    }
}

public class DTExample : OpenApiExample<DT>
{
    public override IOpenApiExample<DT> Build(NamingStrategy namingStrategy = null)
    {
        Examples.Add(
            OpenApiExampleResolver.Resolve(
                "DTExample",
                new DT()
                {
                    id = Guid.NewGuid().ToString(),
                    fullname = "John Doe",
                    money = 0
                },
                namingStrategy
            )
        );

        return this;
    }
}