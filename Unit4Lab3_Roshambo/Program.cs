using System.Text.RegularExpressions;
using Unit4Lab3_Roshambo;

int numberOfWins = 0;
int numberOfLosses = 0;
bool runningProgram = true;

Console.WriteLine("Welcome to the Roshambo game!");
Console.WriteLine();
while (runningProgram)
{
    HumanPlayer thisPlayer = new HumanPlayer();
    PrintIntro(thisPlayer);
    bool gettingPlayerChoice = true;
    while (gettingPlayerChoice)
    {
        string rockPlayerInput = "[r][o][c][k]";
        string randomPlayerInput = "[r][a][n][d][o][m]";
        Console.WriteLine($"{thisPlayer.Name}, which player would you like to play against?");
        Console.WriteLine();
        Console.WriteLine("You can choose 'Rock Player' or 'Random Player'.");
        Console.Write("Enter your choice: ");
        string playerChoice = Console.ReadLine();
        Console.WriteLine();
        if (Regex.IsMatch(playerChoice, rockPlayerInput, RegexOptions.IgnoreCase))
        {
            PlayingRockPlayer(thisPlayer, ref numberOfWins, ref numberOfLosses);
            gettingPlayerChoice = WannaRestart(thisPlayer, numberOfWins, numberOfLosses);
        }
        else if (Regex.IsMatch(playerChoice, randomPlayerInput, RegexOptions.IgnoreCase))
        {
            PlayingRandomPlayer(thisPlayer, ref numberOfWins, ref numberOfLosses);
            gettingPlayerChoice = WannaRestart(thisPlayer, numberOfWins, numberOfLosses);
        }
        else
        {
            Console.WriteLine("Sorry, I didn't understand that response. Please try again.");
            Console.WriteLine();
            gettingPlayerChoice = true;
        }
    }
    runningProgram = false;
}
Console.WriteLine("Thank you for playing the Roshambo game!");
Console.WriteLine("Goodbye...");

static void PauseAndClearScreen()
{
    Console.WriteLine();
    Console.WriteLine("Press Enter to Continue.");
    Console.ReadLine();
    Console.Clear();
}
static void PrintIntro(HumanPlayer thisPlayer)
{
    Console.WriteLine();
    Console.Write($"Hello, ");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write(thisPlayer.Name);
    Console.ResetColor();
    Console.Write("! Let the games begin!");
    Console.WriteLine();
    PauseAndClearScreen();
}
static bool WannaRestart(HumanPlayer thisPlayer, int numberOfWins, int numberOfLosses)
{
    string yesInput = "[y][e][s]";
    string noInput = "[n][o]";
    bool askingUser = true;
    PrintStats(thisPlayer, numberOfWins, numberOfLosses);
    while (askingUser)
    {
        Console.WriteLine("Enter 'YES' to play again or 'NO' to exit the program.");
        Console.Write("Your choice: ");
        string userChoice = Console.ReadLine();
        if (Regex.IsMatch(userChoice, yesInput, RegexOptions.IgnoreCase))
        {
            PauseAndClearScreen();
            return true;
        }
        else if (Regex.IsMatch(userChoice, noInput, RegexOptions.IgnoreCase))
        {
            PauseAndClearScreen();
            return false;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("I'm sorry, I didn't understand that response. Please try again.");
            Console.WriteLine();
        }
    }
    return false;
}
static void PlayingRockPlayer(HumanPlayer thisPlayer, ref int numberOfWins, ref int numberOfLosses)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("You are now playing Roshambo against Rock Player!");
    Console.ResetColor();
    RockPlayer thisRockPlayer = new RockPlayer();
    Console.WriteLine();
    thisPlayer.GenerateRoshambo();
    Console.WriteLine();
    DecipherWinner(thisPlayer, thisRockPlayer.Choice, ref numberOfWins, ref numberOfLosses);
    PauseAndClearScreen();
}
static void PlayingRandomPlayer(HumanPlayer thisPlayer, ref int numberOfWins, ref int numberOfLosses)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("You are now playing Roshambo against Random Player!");
    Console.ResetColor();
    RandomPlayer thisRandomPlayer = new RandomPlayer();
    Console.WriteLine();
    thisRandomPlayer.GenerateRoshambo();
    thisPlayer.GenerateRoshambo();
    Console.WriteLine();
    DecipherWinner(thisPlayer, thisRandomPlayer.Choice, ref numberOfWins, ref numberOfLosses);
    PauseAndClearScreen();
}
static void DecipherWinner(HumanPlayer player, Roshambo opponentChoice, ref int numberOfWins, ref int numberOfLosses)
{
    if (player.Choice==opponentChoice)
    {
        Console.WriteLine(String.Format("{0,41}{1,9}", "Opponent's Choice:", opponentChoice));
        Console.WriteLine(String.Format("{0,41}{1,9}", $"{player.Name}'s Choice:", player.Choice));
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(String.Format("{0,50}", $"{player.Choice} matches {opponentChoice} - there is no winner here!"));
        Console.ResetColor();
    }
    else if ((player.Choice == Roshambo.Rock && opponentChoice == Roshambo.Paper) || 
             (player.Choice == Roshambo.Paper && opponentChoice == Roshambo.Scissors) ||
             (player.Choice == Roshambo.Scissors && opponentChoice == Roshambo.Rock))
    {
        Console.WriteLine(String.Format("{0,41}{1,9}", "Opponent's Choice:", opponentChoice));
        Console.WriteLine(String.Format("{0,41}{1,9}", $"{player.Name}'s Choice:", player.Choice));
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(String.Format("{0,50}", $"{opponentChoice} beats {player.Choice} - YOU LOSE!"));
        Console.ResetColor();
        numberOfLosses++;
    }
    else if ((player.Choice == Roshambo.Rock && opponentChoice == Roshambo.Scissors) ||
             (player.Choice == Roshambo.Paper && opponentChoice == Roshambo.Rock) ||
             (player.Choice == Roshambo.Scissors && opponentChoice == Roshambo.Paper))
    {
        Console.WriteLine(String.Format("{0,41}{1,9}", "Opponent's Choice:", opponentChoice));
        Console.WriteLine(String.Format("{0,41}{1,9}", $"{player.Name}'s Choice:", player.Choice));
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(String.Format("{0,50}", $"{player.Choice} beats {opponentChoice} - YOU WIN!"));
        Console.ResetColor();
        numberOfWins++;
    }
}
static void PrintStats(HumanPlayer thisPlayer, int numberOfWins, int numberOfLosses)
{
    if (numberOfWins == 0)
    {
        if (numberOfLosses == 0)
        {
            Console.WriteLine($"Let's play again {thisPlayer.Name}! You dont have any wins or losses yet!");
            Console.WriteLine();
            Console.WriteLine("Would you like to try and get a win under your belt by playing Roshambo again?");
        }
        else if (numberOfLosses == 1)
        {
            Console.WriteLine($"Yikes, {thisPlayer.Name}! {numberOfLosses} loss and no wins yet!");
            Console.WriteLine();
            Console.WriteLine("Would you like to try and get a win under your belt by playing Roshambo again?");
        }
        else
        {
            Console.WriteLine($"Maybe you should quit now, {thisPlayer.Name}! You have {numberOfLosses} losses and no wins so far!");
            Console.WriteLine();
            Console.WriteLine("Would you like to try and get a win under your belt by playing Roshambo again?");
        }
    }
    else if (numberOfWins == 1)
    {
        if (numberOfLosses == 0)
        {
            Console.WriteLine($"Good start, {thisPlayer.Name}! {numberOfWins} win and no losses yet!");
            Console.WriteLine();
            Console.WriteLine("Would you like to play the Roshambo game again and go for one more?");
        }
        else if (numberOfLosses == 1)
        {
            Console.WriteLine($"Even draw so far, {thisPlayer.Name}! {numberOfLosses} loss and {numberOfWins} win.");
            Console.WriteLine();
            Console.WriteLine("Would you like to try and get a win under your belt by playing Roshambo again?");
        }
        else
        {
            Console.WriteLine($"Things are looking kind of ugly, {thisPlayer.Name}! {numberOfWins} win and {numberOfLosses} losses!");
            Console.WriteLine();
            Console.WriteLine("Would you like to try and get a win under your belt by playing Roshambo again?");
        }
    }
    else
    {
        if (numberOfLosses == 0)
        {
            Console.WriteLine($"Killin' 'em, {thisPlayer.Name}! {numberOfWins} wins and no losses so far! You are on a roll!");
            Console.WriteLine();
            Console.WriteLine("Ready to play again and keep the streak going?");
        }
        else if (numberOfLosses == 1)
        {
            Console.WriteLine($"It's all good, {thisPlayer.Name}! {numberOfLosses} loss is nothing when you have {numberOfWins} wins!");
            Console.WriteLine();
            Console.WriteLine("Would you like to try and get a win under your belt by playing Roshambo again?");
        }
        else
        {
            if (numberOfWins > numberOfLosses)
            {
                Console.WriteLine($"Doing well, {thisPlayer.Name}! You have {numberOfLosses} losses and {numberOfWins} wins so far!");
                Console.WriteLine();
                Console.WriteLine("Would you like to play Roshambo again?");
            }
            else if (numberOfWins == numberOfLosses)
            {
                Console.WriteLine($"It's a draw right now, {thisPlayer.Name}! You have {numberOfLosses} losses and {numberOfWins} wins so far!");
                Console.WriteLine();
                Console.WriteLine("Would you like to play Roshambo again?");
            }
            else
            {
                Console.WriteLine($"Let's maybe slow it down a bit, {thisPlayer.Name}! You now have {numberOfLosses} losses and {numberOfWins} wins so far!");
                Console.WriteLine();
                Console.WriteLine("Would you like to play Roshambo again?");
            }
        }
    }
}