# Tetris

A classic Tetris game implemented in C# using Windows Presentation Foundation (WPF). This project offers a modern take on the timeless puzzle game, featuring smooth animations, intuitive controls, and a clean user interface.

## Features

- **Classic Gameplay**: Experience the traditional Tetris mechanics with seven distinct tetromino shapes.
- **Responsive Controls**: Seamless movement and rotation of blocks for an engaging user experience.
- **Score Tracking**: Keep track of your performance with real-time score updates.
- **Game Over Detection**: Automatic detection of game-over conditions when the grid is filled.
- **Modular Design**: Clean and maintainable codebase with separate classes for each tetromino and game logic components.
  
## Getting Started

### Prerequisites

- Windows 10 or later
- [Visual Studio 2019](https://visualstudio.microsoft.com/) or later with .NET desktop development workload installed

### Installation

1. **Clone the Repository**

   ```bash
   git clone https://github.com/Raguram97/Tetris.git
   ```


2. **Open the Project**

   Navigate to the cloned directory and open `Tetris.sln` with Visual Studio.

3. **Build and Run**

   Press `F5` or click on the "Start" button in Visual Studio to build and run the application.

## Gameplay Controls

- **Left Arrow**: Move tetromino left
- **Right Arrow**: Move tetromino right
- **Up Arrow**: Rotate tetromino
- **Down Arrow**: Soft drop (accelerate downward movement)
- **Spacebar**: Hard drop (instant drop to the bottom)
- **P**: Pause/Resume the game

## Project Structure


```plaintext
Tetris/
├── Assets/               # Contains game assets like images and sounds
├── Fonts/                # Custom fonts used in the game
├── App.xaml              # Application definition
├── App.xaml.cs           # Application logic
├── MainWindow.xaml       # Main window layout
├── MainWindow.xaml.cs    # Main window logic
├── GameGrid.cs
