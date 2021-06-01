using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GreymanRaffleWinnerSelector
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Getting ticket purchases from file");

            // Get the list of users and how many tickets they have purchased from the file
            var purchases = File.ReadAllLines("tickets.csv").Select(x => new TicketPurchase(x)).ToList();

            // Print out some information about the raffle tickets
            Console.WriteLine("Ticket Purchases Read:");
            Console.WriteLine($"People in Raffle: {purchases.Select(x => x.Username).Distinct().Count():N0}");
            Console.WriteLine($"Tickets Purchased: {purchases.Sum(x => x.TicketCount):N0}");

            // Build the bucket of tickets to shuffle and pick from
            var bucket = new List<string>();

            // Go through each purchase
            foreach (var purchase in purchases)
            {
                // Add the right number of tickets to the bucket with their name on them
                bucket.AddRange(Enumerable.Repeat(purchase.Username, purchase.TicketCount));
            }

            // Ask the user how many times we want to run the shuffle
            Console.WriteLine("How many times should we shuffle the bucket?");
            var numberOfShuffles = Convert.ToInt32(Console.ReadLine());

            // Shuffle the list N times
            Console.Write($"Shuffling: 0/{numberOfShuffles:N0} (0.00%)");
            for (var i = 0; i < numberOfShuffles; i++)
            {
                Console.Write($"\rShuffling: {i + 1:N0}/{numberOfShuffles:N0} ({(double)(i + 1) / numberOfShuffles:P})");
                bucket.Shuffle();
            }

            Console.WriteLine($"\nBucket has been shuffled {numberOfShuffles:N0} times");

            Console.WriteLine("Are you ready to pick a winner? (press any key to continue)");
            Console.ReadKey();

            // Select a random name from the bucket
            var winner = bucket.SelectRandom();

            // Write results to disk in case lost
            File.WriteAllText("winner.txt", winner);

            // Notify user of winner and end program
            Console.WriteLine($"The winner is {winner}! Congratulations! \n(also saved to winner.txt)");
        }
    }
}
