using Microsoft.Extensions.Logging;
using PizzaClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PizzaClient.Utils
{
    public class PizzaClientTool
    {
        private readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        private readonly HttpClient client;
        private readonly ILogger<PizzaClientTool> _logger;

        public PizzaClientTool(HttpClient client, ILogger<PizzaClientTool> logger)
        {
            this.client = client;
            this._logger = logger;
        }

        public async Task<PizzaInfo[]> GetPizzasAsync()
        {
            try
            {
                var responseMessage = await this.client.GetAsync("api/pizzainfo");

                if (responseMessage != null)
                {
                    var stream = await responseMessage.Content.ReadAsStreamAsync();
                    return await JsonSerializer.DeserializeAsync<PizzaInfo[]>(stream, options);
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
            return new PizzaInfo[] { };

        }
    }
}
