using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GuessNumberGame

{

    /// <summary>
    /// Asks the user to guess a number between a certain range and then guesses that number in the fewest possible turns
    /// </summary>
    public class ComPlays
    {
        #region Public Properties
        /// <summary>
        /// the largest number we ask the user to guess, between 0 and this number
        /// </summary>
        ///define max number
        public int MaximumNumber { get; set; } = 100; 
        /// <summary>
        /// the current number of guesses the computer has had
        /// </summary>
        ///keep track of guesses
        public int CurrentNumberOfGuesses { get; private set; }
        /// <summary>
        /// the current known minimum number the user is thinking of
        /// </summary>
        ///start guess from
        public int CurrentGuessMinimum { get; private set; }
        /// <summary>
        /// The current known maximum number the user is thinking of
        /// </summary>
        ///the start guess to (half of max)
        public int CurrentGuessMaximum { get; private set; }
        #endregion
        #region .ctor
        /// <summary>
        /// Default constructor
        /// </summary>
        public ComPlays()
        {
            //set default maximum number
            this.MaximumNumber = 100;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// asks the user to think of a number
        /// </summary>
        public void InformUser()
        {
            //Ask user to think of number between 0 and MaximumNumber
            Console.WriteLine($"I want you to think of a number between 0 and {this.MaximumNumber}");
            Console.ReadLine();
        }
        /// <summary>
        /// ask the user a series of questions to discover the number they are thinking of
        /// </summary>
        public void DiscoverNumber()
        {
            //clear variables to their inital values before a discovery
            this.CurrentNumberOfGuesses = 0;
            this.CurrentGuessMaximum = this.MaximumNumber / 2;
            this.CurrentGuessMinimum = 0;
            //while the guess isn't the same as max number
            while (this.CurrentGuessMinimum != this.CurrentGuessMaximum)
            {
                //increase guess amount (by 1)
                this.CurrentNumberOfGuesses++;
                //ask the user if their number is between the guess range.
                Console.WriteLine($"is you number between {this.CurrentGuessMinimum} and {this.CurrentGuessMaximum}?");
                string response = Console.ReadLine();
                //if user confirmed thier number is within the range
                if (response?.ToLower().FirstOrDefault() == 'y' || response?.FirstOrDefault() == 'Y')
                {
                    //We know the number is between guessMin and guessMax
                    //So set the new maximum number
                    this.MaximumNumber = this.CurrentGuessMaximum;
                    //change the next guess range to half of the new max range
                    this.CurrentGuessMaximum = this.CurrentGuessMaximum - (this.CurrentGuessMaximum - this.CurrentGuessMinimum) / 2;
                }
                //The number is greater than guessMax and less than or equal to max
                else
                {
                    //the new minimum is above the old maximu
                    this.CurrentGuessMinimum = this.CurrentGuessMaximum + 1;
                    //guess the bottom half of the new range
                    int remainingDifference = this.MaximumNumber - this.CurrentGuessMaximum;
                    //set the guess max to half way between guessMin and guessMax
                    //NOTE:Math.Ceiling will round up the remaining difference to 2, if the difference is 3
                    this.CurrentGuessMaximum += (int)Math.Ceiling(remainingDifference / 2f);
                }
                //if we only have 2 numbers left, guess one of them
                if (this.CurrentGuessMinimum + 1 == this.MaximumNumber)
                {
                    //increase guess amount by 1
                    this.CurrentNumberOfGuesses++;
                    //ask the user if their number is the lower number
                    Console.WriteLine($"is your number {this.CurrentGuessMinimum}?");
                    response = Console.ReadLine();
                    //if the user confirmed their number is the lower number
                    if (response?.ToLower().FirstOrDefault() == 'y')
                    {
                        break;
                    }
                    else
                    {
                        this.CurrentGuessMinimum = this.MaximumNumber;
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// announce the number the user was thinking of
        /// </summary>
        public void AnnounceResults()
        {
            //tell the user their number
            Console.WriteLine($"**Your number is {this.CurrentGuessMinimum}");
            //let the user know how many guesses it took
            Console.WriteLine($"Guessed in {this.CurrentNumberOfGuesses} guesses");
            Console.ReadLine();
        }
        #endregion
    }
}
