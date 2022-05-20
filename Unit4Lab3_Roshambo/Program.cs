﻿using System.Text.RegularExpressions;
using Unit4Lab3_Roshambo;

Console.WriteLine("Welcome to the Roshambo game!");
Console.WriteLine();

bool runningProgram = true;
while (runningProgram)
{
    HumanPlayer thisPlayer = new HumanPlayer();
    Console.WriteLine();
    Console.Write($"Hello, ");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write(thisPlayer.Name);
    Console.ResetColor();
    Console.Write("! Let the games begin!");
    Console.WriteLine();
    PauseAndClearScreen();

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
            PlayingRockPlayer(thisPlayer);
            gettingPlayerChoice = WannaRestart();
        }
        else if (Regex.IsMatch(playerChoice, randomPlayerInput, RegexOptions.IgnoreCase))
        {
            PlayingRandomPlayer(thisPlayer);
            gettingPlayerChoice = WannaRestart();
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
static bool WannaRestart()
{
    string yesInput = "[y][e][s]";
    string noInput = "[n][o]";
    bool askingUser = true;
    while (askingUser)
    {
        Console.WriteLine("Would you like to play the Roshambo game again?");
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
static void PlayingRockPlayer(HumanPlayer thisPlayer)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("You are now playing Roshambo against Rock Player!");
    Console.ResetColor();
    RockPlayer thisRockPlayer = new RockPlayer();
    Console.WriteLine();
    Roshambo choice = thisPlayer.GenerateRoshambo();
    Console.WriteLine();
    if (thisPlayer.Choice == Roshambo.Rock)
    {
        Console.WriteLine($"Rock Player Choice: {thisRockPlayer.Choice}");
        Console.WriteLine($"{thisPlayer.Name} Choice: {thisPlayer.Choice}");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Rock matches Rock - there is no winner here!");
        Console.ResetColor();
        PauseAndClearScreen();
    }
    else if (thisPlayer.Choice == Roshambo.Paper)
    {
        Console.WriteLine($"Rock Player Choice: {thisRockPlayer.Choice}");
        Console.WriteLine($"{thisPlayer.Name} Choice: {thisPlayer.Choice}");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Paper beats Rock - YOU WIN!");
        Console.ResetColor();
        PauseAndClearScreen();
    }
    else
    {
        Console.WriteLine($"Rock Player Choice: {thisRockPlayer.Choice}");
        Console.WriteLine($"{thisPlayer.Name} Choice: {thisPlayer.Choice}");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Rock beats Scissors - YOU LOSE!");
        Console.ResetColor();
        PauseAndClearScreen();
    }
}
static void PlayingRandomPlayer(HumanPlayer thisPlayer)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("You are now playing Roshambo against Random Player!");
    Console.ResetColor();
    RandomPlayer thisRandomPlayer = new RandomPlayer();
    Console.WriteLine();
    Roshambo choice = thisRandomPlayer.GenerateRoshambo();
    thisPlayer.GenerateRoshambo();
    Console.WriteLine();
    if (thisPlayer.Choice == Roshambo.Rock)
    {
        if (thisRandomPlayer.Choice == Roshambo.Rock)
        {
            Console.WriteLine($"Random Player Choice: {thisRandomPlayer.Choice}");
            Console.WriteLine($"{thisPlayer.Name} Choice: {thisPlayer.Choice}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Rock matches Rock - there is no winner here!");
            Console.ResetColor();
            PauseAndClearScreen();
        }
        else if (thisRandomPlayer.Choice == Roshambo.Paper)
        {
            Console.WriteLine($"Random Player Choice: {thisRandomPlayer.Choice}");
            Console.WriteLine($"{thisPlayer.Name} Choice: {thisPlayer.Choice}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Paper beats rock - YOU LOSE!");
            Console.ResetColor();
            PauseAndClearScreen();
        }
        else
        {
            Console.WriteLine($"Random Player Choice: {thisRandomPlayer.Choice}");
            Console.WriteLine($"{thisPlayer.Name} Choice: {thisPlayer.Choice}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Rock beats Sciossors - YOU WIN!");
            Console.ResetColor();
            PauseAndClearScreen();
        }
    }
    else if (thisPlayer.Choice == Roshambo.Paper)
    {
        if (thisRandomPlayer.Choice == Roshambo.Rock)
        {
            Console.WriteLine($"Random Player Choice: {thisRandomPlayer.Choice}");
            Console.WriteLine($"{thisPlayer.Name} Choice: {thisPlayer.Choice}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Paper beats rock - YOU WIN!");
            Console.ResetColor();
            PauseAndClearScreen();
        }
        else if (thisRandomPlayer.Choice == Roshambo.Paper)
        {
            Console.WriteLine($"Random Player Choice: {thisRandomPlayer.Choice}");
            Console.WriteLine($"{thisPlayer.Name} Choice: {thisPlayer.Choice}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Paper matches paper - there is no winner here!");
            Console.ResetColor();
            PauseAndClearScreen();
        }
        else
        {
            Console.WriteLine($"Random Player Choice: {thisRandomPlayer.Choice}");
            Console.WriteLine($"{thisPlayer.Name} Choice: {thisPlayer.Choice}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Scissors beats paper - YOU LOSE!");
            Console.ResetColor();
            PauseAndClearScreen();
        }
    }
    else
    {
        if (thisRandomPlayer.Choice == Roshambo.Rock)
        {
            Console.WriteLine($"Random Player Choice: {thisRandomPlayer.Choice}");
            Console.WriteLine($"{thisPlayer.Name} Choice: {thisPlayer.Choice}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Rock beats sciossors - YOU LOSE!");
            Console.ResetColor();
            PauseAndClearScreen();
        }
        else if (thisRandomPlayer.Choice == Roshambo.Paper)
        {
            Console.WriteLine($"Random Player Choice: {thisRandomPlayer.Choice}");
            Console.WriteLine($"{thisPlayer.Name} Choice: {thisPlayer.Choice}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Scissors beats paper - YOU WIN!");
            Console.ResetColor();
            PauseAndClearScreen();
        }
        else
        {
            Console.WriteLine($"Random Player Choice: {thisRandomPlayer.Choice}");
            Console.WriteLine($"{thisPlayer.Name} Choice: {thisPlayer.Choice}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Scissors matches scissors - there is no winner here!");
            Console.ResetColor();
            PauseAndClearScreen();
        }
    }
}