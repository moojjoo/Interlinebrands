using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientSample
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

        public async Task<List<Movie>> GetAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(3000);

            cancellationToken.ThrowIfCancellationRequested();

            HttpResponseMessage response = await client.GetAsync("api/movieitem", cancellationToken);
            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Movie>>(stringResult);
            }
            return new List<Movie>();

        }



    }
}
