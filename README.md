# Math Game

Welcome to the Math Game! This is a console-based math game built in C# where users can test their arithmetic skills.
Below you'll find instructions on how to run the game and details about its features.

## Features

- **Basic Operations**: Includes addition, subtraction, multiplication, and division.
- **Integer Results**: Divisions will always result in integer values; no fractional results will be presented.
- **User Menu**: A menu allows users to choose an operation, view game history, and more.
- **Game History**: Previous games are recorded in a list and can be reviewed during the current session.
- **Difficulty Levels**: The game includes different levels of difficulty.
- **Timer**: A timer tracks how long it takes for the user to finish the game.
- **Question Count**: Users can choose the number of questions in each game.
- **Random Game**: A special mode where questions of random operations are presented.

## Requirements

To run this game, you need:
- .NET Core SDK (version 3.1 or later)
- A text editor or IDE (like Visual Studio or Visual Studio Code)

## Getting Started

### Cloning the Repository

1. Clone the repository to your local machine:
   ```bash
   git clone https://github.com/yourusername/MathGame.git
   ```

2. Navigate to the project directory:
   ```bash
   cd MathGame
   ```

### Building the Game

1. Open a terminal or command prompt in the project directory.
2. Build the project using the .NET Core CLI:
   ```bash
   dotnet build
   ```

### Running the Game

1. After building the project, run the game with the following command:
   ```bash
   dotnet run
   ```

2. Follow the on-screen menu to start playing the game, choose an operation, view game history, and more.

## Game Menu

When you start the game, you will see a menu with the following options:

1. **Start New Game**: Begin a new game with the option to select difficulty and the number of questions.
2. **View Game History**: View a list of previously played games and their results.
3. **Random Game**: Play a game where questions are presented with random operations.
4. **Exit**: Close the application.

## Additional Notes

- The game does not save game history after the program is closed. History is only available during the current session.
- If you encounter any issues or have suggestions for improvements, please feel free to open an issue on the [GitHub repository](https://github.com/bhavees/ConsoleMathGame/issues).

Thank you for playing the Math Game! Have fun and improve your math skills!
