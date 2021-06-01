using System;

namespace GreymanRaffleWinnerSelector
{
    /// <summary>
    /// Represents a purchase of tickets by a user
    /// </summary>
    public class TicketPurchase
    {
        /// <summary>
        /// The username of the person who purchased the tickets
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The number of tickets the user purchased
        /// </summary>
        public int TicketCount { get; set; }

        /// <summary>
        /// Takes in a line from a csv file and parses the values
        /// </summary>
        /// <param name="csvLine">A line from a CSV file. Example: username,count</param>
        public TicketPurchase(string csvLine)
        {
            // Split the line by the commas
            var values = csvLine.Split(',');
            
            // Grab the values and put them into their respective properties
            Username = values[0];
            TicketCount = Convert.ToInt32(values[1]);
        }
    }
}