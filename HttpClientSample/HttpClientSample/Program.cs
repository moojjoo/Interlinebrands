using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("One Moment Please...");

            var repository = new MovieRepository();
            var movieTask = repository.GetAsync(CancellationToken.None);

            movieTask.ContinueWith(task =>
            {
            var movie = task.Result;
            foreach (var movieItem in movie)           
                Console.Write(movieItem.ToString());
                Environment.Exit(0);
            },
            TaskContinuationOptions.OnlyOnRanToCompletion);

            Console.Read();
        }
    }
}

