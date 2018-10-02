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
            foreach (var movieModel in movie)           
                Console.Write(movieModel.ID 
                    + " " + movieModel.Title
                    + " " + movieModel.Genre
                    + " " + movieModel.ReleaseDate
                    + " " + movieModel.Price
                    + Environment.NewLine);
                

                //Environment.Exit(0);
            },
            TaskContinuationOptions.OnlyOnRanToCompletion);

            Console.ReadLine();
        }
    }
}

