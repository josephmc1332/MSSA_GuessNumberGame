using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanPlays HP = new HumanPlays();
            HP.RandomNumber();  

            //create a new instance of our number guesser class
            var numberGuesser = new ComPlays();
            //change default to 200
            numberGuesser.MaximumNumber = 1000;    
            //ask user to think of a number
            numberGuesser.InformUser();
            //discover the number the user is thinking of
            numberGuesser.DiscoverNumber();
            //announce the results
            numberGuesser.AnnounceResults();
        }
    }
}
