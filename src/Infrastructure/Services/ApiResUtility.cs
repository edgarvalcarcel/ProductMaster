using System.Text.Json.Nodes;
using Azure.Core;
using Newtonsoft.Json;
using RestSharp;

namespace ProductMaster.Infrastructure.Shared.Services
{
    public static class ApiResUtility
    {
        public static T? Request<T>(string resource, string key) where T : new()
        {
            string newRequest = "";
            var client = new RestClient(resource);

            if (!string.IsNullOrWhiteSpace(key))
                newRequest = resource + key;
            else
                newRequest = resource;
            var request = new RestRequest(newRequest, Method.Get);

            var response = client.Execute<T>(request).Data; 
            return response; 
        } 
    }
}
