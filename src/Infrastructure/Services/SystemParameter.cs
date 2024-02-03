using System.Text.Json.Serialization;

namespace ProductMaster.Infrastructure.Shared.Services
{
    public class SystemParameter
    {
        [JsonPropertyName("data")] public Data? Data { get; set; }
        [JsonPropertyName("id")] public int? Id { get; set; }
        [JsonPropertyName("title")] public string? Title { get; set; }


    }
    public class Data
    {
        [JsonPropertyName("keyValue")] public string? KeyValue { get; set; }
        [JsonPropertyName("failed")] public bool Failed { get; set; }
        [JsonPropertyName("message")] public string? Message { get; set; }
        [JsonPropertyName("succeeded")] public bool Succeeded { get; set; }
    }

    public class ResponseAPI
    {
        [JsonPropertyName("Discount")] public string? Discount { get; set; }
        [JsonPropertyName("ProductId")] public string? ProductId { get; set; } 
    }
}
