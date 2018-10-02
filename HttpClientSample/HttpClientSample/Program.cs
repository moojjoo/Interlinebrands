using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientSample
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowMovie(Movie movie)
        {
            Console.WriteLine($"Name: {movie.Title}" +
                $"{movie.Price}\tGenre: {movie.Genre}");
        }

        static async Task<Uri> CreateMovieAsync(Movie movie)
        {
            HttpRequestMessage response = await client.PostAsJsonAsync(
                "api/movieitem", movie);
            response.EnsureSuccessStatusCode();
            //return URI of the created resource
            return response.Headers.Location;
        }


    }
}
