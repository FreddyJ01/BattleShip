# BattleShip

A modern recreation of the classic game Battleship.

## Overview

This repository contains an implementation of the Battleship game in **C#**, recreating the classic strategic guessing game where two players attempt to sink each other's fleet of ships. The project aims to provide a fun, interactive experience, whether played locally or online.

## Features

- Classic Battleship gameplay
- Player vs. Player mode (local or online)
- Visual game board with ship placement and attack feedback
- Configurable board size and ship types
- Score tracking and win/loss statistics

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (Recommended: .NET 6 or newer)
- Any additional dependencies (listed in `.csproj` or documented in the repo)

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/FreddyJ01/BattleShip.git
    cd BattleShip
    ```

2. Restore dependencies:
    ```bash
    dotnet restore
    ```

### Running the Game

- For a local game, run:
    ```bash
    dotnet run --project src/BattleShip
    ```
    *(Update the path if the main project is located elsewhere)*

- For online play, follow instructions in the `docs/` folder (coming soon).

## Gameplay

1. Place your ships on your board.
2. Take turns guessing coordinates to attack your opponent's ships.
3. First player to sink all opponent ships wins!

## Project Structure

```
BattleShip/
├── src/          # Game logic and source code (C# projects)
├── assets/       # Images, sounds, and other resources
├── docs/         # Documentation
├── tests/        # Unit and integration tests
├── README.md
└── LICENSE
```

## Contributing

Contributions are welcome! Please open issues and pull requests for suggestions, bug fixes, or new features.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/new-feature`)
3. Commit your changes (`git commit -am 'Add new feature'`)
4. Push to the branch (`git push origin feature/new-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Credits

Fred Johnson [@freddyj01](https://github.com/freddyj01)  
Matthew Hill [@hillmatthew2000](https://github.com/hillmatthew2000)

---
*This README is a template. Update sections as project development progresses!*
