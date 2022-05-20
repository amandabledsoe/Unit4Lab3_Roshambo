using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Unit4Lab3_Roshambo
{
    public enum Roshambo
    {
        Rock,
        Paper,
        Scissors
    }
    abstract class Player
    {
        public string? Name { get; set; }
        public Roshambo Choice { get; set; }

        public virtual Roshambo GenerateRoshambo()
        {
            return Roshambo.Rock;
        }
    }
    class RockPlayer : Player
    {
        public override Roshambo GenerateRoshambo()
        {
            return Roshambo.Rock;
        }
    }
    class RandomPlayer : Player
    {
        public override Roshambo GenerateRoshambo()
        {
            Random rnd = new Random();
            int num = rnd.Next(3);
            Choice = (Roshambo)num;
            return Choice;
        }
    }
    class HumanPlayer : Player
    {
        public HumanPlayer()
        {
            Console.Write("Please enter your name: ");
            Name =  Console.ReadLine();
        }
        public override Roshambo GenerateRoshambo()
        {
            string rockInput = "[r][o][c][k]";
            string paperInput = "[p][a][p][e][r]";
            string scissorsInput = "[s][c][i][s][s][o][r][s]";
            bool gettingInput = true;
            while (gettingInput)
            {
                Console.WriteLine("Please enter your battle choice: Rock, Paper or Scissors.");
                Console.Write("Your battle choice: ");
                string input = Console.ReadLine();

                if (Regex.IsMatch(input, rockInput, RegexOptions.IgnoreCase))
                {
                    Choice = Roshambo.Rock;
                    return Roshambo.Rock;
                }
                else if (Regex.IsMatch(input, paperInput, RegexOptions.IgnoreCase))
                {
                    Choice = Roshambo.Paper;
                    return Roshambo.Paper;
                }
                else if (Regex.IsMatch(input, scissorsInput, RegexOptions.IgnoreCase))
                {
                    Choice = Roshambo.Scissors;
                    return Roshambo.Scissors;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Sorry, I didnt recognize that response. Please try again.");
                    Console.WriteLine();
                }
            }
            return Roshambo.Rock;
        }
    }
}
