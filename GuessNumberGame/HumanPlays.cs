using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberGame
{
    class HumanPlays
    {
        private int counter = 0;
        public HumanPlays()
        {
            Counter = counter;
        }
        public int Counter { get; set; }
        public int UserResponse { get; set; }
        public int ComputerNumber { get; set; }
        //Start Game//
        public void RandomNumber()
        {
            Random rdm = new Random();
            ComputerNumber = rdm.Next(1, 1000);
            GuessScreen();
        }
        public void GuessScreen()
        {
            Console.WriteLine("Guess my number.. (1 - 1000)");
            string response = Console.ReadLine();
            IsInvalid(response);
        }
        public void Case()
        {
            if (ComputerNumber > UserResponse) TooLow();

            if (ComputerNumber < UserResponse) TooHigh();

            if (ComputerNumber == UserResponse) YouWin();
        }
        public void TooHigh()
        {
            Attempts();
            Console.WriteLine("Wrong guess! You're too high. Try again.");
            GuessScreen();
        }
        public void TooLow()
        {
            Attempts();
            Console.WriteLine("Wrong guess! You're too low. Try agian");
            GuessScreen();
        }
        public void YouWin()
        {
            Attempts();
            Console.WriteLine("You Win!!");
            Console.WriteLine("My turn. Press enter");
        }
        public void KeepScreen()
        {
            Console.ReadLine();
            Console.Clear();
        }
        public void Attempts()
        {
            Console.WriteLine($"\tNumber of attempts: {Counter}");
            Console.WriteLine();
        }
        public void IsInvalid(string response)
        {          
            bool result = false;
            int worked;
            while (result == false)
            {
                result = int.TryParse(response, out worked);
                if (result == true)
                {
                    UserResponse = worked;
                    break;
                }              
                Console.WriteLine("Invalid Entry. Pick a number between 1 and 1000");
                response = Console.ReadLine();
                }
            if (UserResponse > 0 && UserResponse <= 1000)
            {
                Counter++;
                Case();
            }
        }

    }
}
