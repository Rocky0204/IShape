# Shape Drawing System

A .NET console application that demonstrates object-oriented programming principles by drawing various geometric shapes. Mainly using abstraction.

## Features

- **Circle**: Draws filled circles with configurable radius
- **Rectangle**: Draws filled rectangles with configurable dimensions
- **Triangle**: Draws various triangle types (Right, Equilateral, Isosceles, Inverted)
- **Polymorphism**: All shapes implement the `IShape` interface
- **Abstraction**: Uses abstract base class for common functionality

## Shapes Supported

1. **Circle**
   - Configurable radius
   - Default radius: 5 units

2. **Rectangle**
   - Configurable width and height
   - Default dimensions: 10x5 units
   - Resizable functionality

3. **Triangle**
   - Multiple types: Right, Equilateral, Isosceles, Inverted
   - Configurable height
   - Default height: 6 units

## Project Structure
IShape/
├── IShape/ # Main project
│ ├── Program.cs # Main application entry point
│ ├── Circle.cs # Circle shape implementation
│ ├── Rectangle.cs # Rectangle shape implementation
│ ├── Triangle.cs # Triangle shape implementation
│ ├── IShape.cs # IShape interface
│ ├── ShapeBase.cs # Abstract base class for shapes
│ └── IShape.csproj # Project file
├── ShapeTests/ # Unit test project
│ ├── UnitTest1.cs # Comprehensive unit tests
│ └── ShapeTests.csproj # Test project file
├── IShape.sln # Solution file
├── README.md # This file
└── .gitignore # Git ignore rules


## Prerequisites

- .NET 8.0 SDK or later
- Git (for version control)

## Building and Running

### Using .NET CLI

# Build the solution
dotnet build

# Run the main application
dotnet run --project IShape

# Run all tests
dotnet test

# Run specific project tests
dotnet test --project ShapeTests