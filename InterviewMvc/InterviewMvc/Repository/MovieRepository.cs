using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using InterviewMvc.Models;
using Newtonsoft.Json;

namespace InterviewMvc.Repository
{
    class MovieRepository
    {
        HttpClient client = new HttpClient();

        public MovieRepository()
        {
            client.BaseAddress = new Uri("https://localhost:44309/");
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<MovieModel>> GetAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(3000);

            cancellationToken.ThrowIfCancellationRequested();

            HttpResponseMessage response = await client.GetAsync("api/movie", cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<MovieModel>>(stringResult);
            }
            return new List<MovieModel>();

        }
    }
}
