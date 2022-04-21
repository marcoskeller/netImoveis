using Microsoft.Extensions.Logging;
using netImoveis.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace netImoveis.Data.Repository
{
    public class ImoveisRepository : IImoveisRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ImoveisRepository> _logger;

        public ImoveisRepository(HttpClient httpClient, ILogger<ImoveisRepository> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<Imoveis>> List()
        {
            var response = await _httpClient.GetAsync($"/api/teste/imoveis/");
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var context = $"Error searching person";
                throw new HttpRequestException();
            }
            
            return (IEnumerable<Imoveis>)JsonSerializer.Deserialize<Imoveis>(responseBody);
            //return JsonConvert.DeserializeObject<Imoveis>(responseBody);
        }

        
    }
}
