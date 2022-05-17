This my solution for Unit 4: Lab 3 "Roshambo" in the 2022 C# .NET After-Hours Boot Camp at Grand Circus.

# ROSHAMBO: ROCK PAPER SCISSORS

### Objectives: 
- Enumerations, Abstract Classes

### Task: 
- Create a rock, paper, scissors game.

### What will the application do?
- The application prompts the player to enter a name and select an opponent.
- The application prompts the player to select rock, paper, or scissors. Then, the application displays the player’s choice, the opponent’s choice, and the result of the match.
- The application continues until the user doesn’t want to play anymore.
- If the user makes an invalid selection, the application should display an appropriate error message and prompt the user again until the user makes a valid selection.

### Build Specifications:
- Create an enumeration called Roshambo that has three values: rock, paper, and scissors.
- Create an abstract class named Player that stores a name and a Roshambo value. This class should include a method named GenerateRoshambo that allows an inheriting class to generate and return a Roshambo value.
- Create and name three player subclasses:
- RockPlayer - Always throws Rock 
- RandomPlayer - Picks and throws a value at random 
- HumanPlayer - Allows the user to select and throw a value. Upon creating this class, allow the user to input their name.
- Create a main where you create a HumanPlayer and then allow them to choose their opponent: either RockPlayer or RandomPlayer.
- Validate your user inputs throughout your app. Try catch blocks, if statements, or any other method of validation is good.

### Hints:
- Paper beats rock, rock beats scissors, scissors beats paper.

### Extra Challenges:
- Create a Validator class to handle validation of all console input. It could have methods like GetYN (gets Y/y or N/n), GetOtherPlayer (accepts the names of your two players), GetRoshambo (accepts r/p/s and/or rock/paper/scissors).
- Keep track of wins and losses, and display them at the end of each session.


### Console Preview:
```
Welcome to Rock Paper Scissors!

Enter your name: Chioke

Would you like to play against The Jets or TheSharks (j/s)?: J

Rock, paper, or scissors? (R/P/S): r

Chioke: rock
The Jets: rock
Draw!

Play again? (y/n): Y

Rock, paper, or scissors? (R/P/S): p

Chioke: paper
TheJets: rock
Chioke wins!

Play again? (y/n): y

Rock, paper, or scissors? (R/P/S): s

Chioke: scissors
The Jets: rock
The Jets wins!

Play again? (y/n): N
```
