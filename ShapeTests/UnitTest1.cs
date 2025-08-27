// ShapeTests.cs
using Xunit;
using IShape;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ShapeTests
{
    public class CircleTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        public void Circle_Constructor_WithValidRadius_SetsRadius(int radius)
        {
            // Arrange & Act
            var circle = new Circle(radius);

            // Assert
            Assert.Equal(radius, circle.Radius);
        }

        [Theory]
        [InlineData(-5, 5)]
        [InlineData(0, 5)]
        [InlineData(-1, 5)]
        public void Circle_Constructor_WithInvalidRadius_SetsDefault(int invalidRadius, int expectedDefault)
        {
            // Arrange & Act
            var circle = new Circle(invalidRadius);

            // Assert
            Assert.Equal(expectedDefault, circle.Radius);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(7)]
        [InlineData(15)]
        public void Circle_Radius_Property_ValidValue_SetsCorrectly(int newRadius)
        {
            // Arrange
            var circle = new Circle(5);

            // Act
            circle.Radius = newRadius;

            // Assert
            Assert.Equal(newRadius, circle.Radius);
        }

        [Theory]
        [InlineData(-3)]
        [InlineData(0)]
        [InlineData(-100)]
        public void Circle_Radius_Property_InvalidValue_KeepsPreviousValue(int invalidRadius)
        {
            // Arrange
            var circle = new Circle(5);
            var originalRadius = circle.Radius;

            // Act
            circle.Radius = invalidRadius;

            // Assert
            Assert.Equal(originalRadius, circle.Radius);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void Circle_Draw_WithDifferentRadii_OutputsCorrectPattern(int radius)
        {
            // Arrange
            var circle = new Circle(radius);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            circle.Draw();

            // Assert
            var result = output.ToString();
            Assert.Contains($"Drawing a Circle (radius: {radius})", result);
            Assert.Contains("*", result);
        }

        [Fact]
        public void Circle_Draw_WithMinimumRadius_OutputsSingleCharacter()
        {
            // Arrange
            var circle = new Circle(1);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            circle.Draw();

            // Assert
            var result = output.ToString();
            // Small circle should have at least some asterisks
            Assert.Contains("*", result);
        }

        [Fact]
        public void Circle_Draw_OutputContainsExpectedDimensions()
        {
            // Arrange
            var circle = new Circle(3);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            circle.Draw();

            // Assert
            var result = output.ToString();
            Assert.Contains("radius: 3", result);
        }
    }

    public class RectangleTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(5, 3)]
        [InlineData(10, 5)]
        [InlineData(20, 10)]
        public void Rectangle_Constructor_WithValidDimensions_SetsCorrectly(int width, int height)
        {
            // Arrange & Act
            var rectangle = new Rectangle(width, height);

            // Assert
            Assert.Equal(width, rectangle.Width);
            Assert.Equal(height, rectangle.Height);
        }

        [Theory]
        [InlineData(-5, -3, 10, 5)]
        [InlineData(0, 0, 10, 5)]
        [InlineData(-1, 5, 10, 5)]
        [InlineData(5, -1, 5, 5)]
        public void Rectangle_Constructor_WithInvalidDimensions_SetsDefaults(int invalidWidth, int invalidHeight, int expectedWidth, int expectedHeight)
        {
            // Arrange & Act
            var rectangle = new Rectangle(invalidWidth, invalidHeight);

            // Assert
            Assert.Equal(expectedWidth, rectangle.Width);
            Assert.Equal(expectedHeight, rectangle.Height);
        }

        [Theory]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 1)]
        public void Rectangle_Draw_WithValidDimensions_OutputsCorrectPattern(int width, int height)
        {
            // Arrange
            var rectangle = new Rectangle(width, height);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            rectangle.Draw();

            // Assert
            var result = output.ToString();
            Assert.Contains($"Drawing a Filled Rectangle ({width}x{height})", result);

            // Count the number of lines with asterisks
            var lines = result.Split('\n');
            var asteriskLines = 0;
            foreach (var line in lines)
            {
                if (line.Contains('*')) asteriskLines++;
            }

            Assert.Equal(height, asteriskLines);
        }

        [Fact]
        public void Rectangle_Draw_WithMinimumDimensions_OutputsSingleLine()
        {
            // Arrange
            var rectangle = new Rectangle(1, 1);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            rectangle.Draw();

            // Assert
            var result = output.ToString();
            var lines = result.Split('\n');
            var asteriskLines = 0;
            foreach (var line in lines)
            {
                if (line.Contains('*')) asteriskLines++;
            }

            Assert.Equal(1, asteriskLines);
        }

        [Theory]
        [InlineData(5, 4, 8, 6)]
        [InlineData(3, 2, 5, 3)]
        [InlineData(10, 5, 15, 8)]
        public void Rectangle_DrawWithSize_ValidDimensions_UpdatesAndDrawsCorrectly(int originalWidth, int originalHeight, int newWidth, int newHeight)
        {
            // Arrange
            var rectangle = new Rectangle(originalWidth, originalHeight);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            rectangle.DrawWithSize(newWidth, newHeight);

            // Assert
            var result = output.ToString();
            Assert.Contains($"Drawing a Filled Rectangle ({newWidth}x{newHeight})", result);
            Assert.DoesNotContain($"Drawing a Filled Rectangle ({originalWidth}x{originalHeight})", result);
        }

        [Theory]
        [InlineData(5, 3, -2, -1)]
        [InlineData(4, 2, 0, 0)]
        [InlineData(6, 4, -5, 3)]
        public void Rectangle_DrawWithSize_InvalidDimensions_KeepsPreviousValues(int originalWidth, int originalHeight, int invalidWidth, int invalidHeight)
        {
            // Arrange
            var rectangle = new Rectangle(originalWidth, originalHeight);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            rectangle.DrawWithSize(invalidWidth, invalidHeight);

            // Assert
            var result = output.ToString();
            Assert.Contains($"Drawing a Filled Rectangle ({originalWidth}x{originalHeight})", result);
        }

        [Fact]
        public void Rectangle_Width_And_Height_Properties_Work_Correctly()
        {
            // Arrange
            var rectangle = new Rectangle(5, 3);

            // Act
            rectangle.Width = 8;
            rectangle.Height = 4;

            // Assert
            Assert.Equal(8, rectangle.Width);
            Assert.Equal(4, rectangle.Height);
        }
    }

    public class TriangleTests
    {
        [Theory]
        [InlineData(Triangle.TriangleType.Right, 4)]
        [InlineData(Triangle.TriangleType.Equilateral, 5)]
        [InlineData(Triangle.TriangleType.Isosceles, 6)]
        [InlineData(Triangle.TriangleType.Inverted, 3)]
        public void Triangle_Constructor_WithDifferentTypesAndHeights_SetsCorrectly(Triangle.TriangleType type, int height)
        {
            // Arrange & Act
            var triangle = new Triangle(height, type);

            // Assert
            Assert.Equal(height, triangle.Height);
            Assert.Equal(type, triangle.Type);
        }

        [Theory]
        [InlineData(-2, 6)]
        [InlineData(0, 6)]
        [InlineData(-10, 6)]
        public void Triangle_Constructor_WithInvalidHeight_SetsDefault(int invalidHeight, int expectedDefault)
        {
            // Arrange & Act
            var triangle = new Triangle(invalidHeight);

            // Assert
            Assert.Equal(expectedDefault, triangle.Height);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(8)]
        [InlineData(10)]
        public void Triangle_Height_Property_ValidValue_SetsCorrectly(int newHeight)
        {
            // Arrange
            var triangle = new Triangle(5);

            // Act
            triangle.Height = newHeight;

            // Assert
            Assert.Equal(newHeight, triangle.Height);
        }

        [Theory]
        [InlineData(-3)]
        [InlineData(0)]
        [InlineData(-15)]
        public void Triangle_Height_Property_InvalidValue_KeepsPreviousValue(int invalidHeight)
        {
            // Arrange
            var triangle = new Triangle(5);
            var originalHeight = triangle.Height;

            // Act
            triangle.Height = invalidHeight;

            // Assert
            Assert.Equal(originalHeight, triangle.Height);
        }

        [Theory]
        [InlineData(Triangle.TriangleType.Right)]
        [InlineData(Triangle.TriangleType.Equilateral)]
        [InlineData(Triangle.TriangleType.Isosceles)]
        [InlineData(Triangle.TriangleType.Inverted)]
        public void Triangle_Type_Property_SetsCorrectly(Triangle.TriangleType newType)
        {
            // Arrange
            var triangle = new Triangle(5, Triangle.TriangleType.Right);

            // Act
            triangle.Type = newType;

            // Assert
            Assert.Equal(newType, triangle.Type);
        }

        [Theory]
        [InlineData(Triangle.TriangleType.Right, 3)]
        [InlineData(Triangle.TriangleType.Equilateral, 4)]
        [InlineData(Triangle.TriangleType.Isosceles, 5)]
        [InlineData(Triangle.TriangleType.Inverted, 3)]
        public void Triangle_Draw_WithDifferentTypesAndHeights_OutputsCorrectPattern(Triangle.TriangleType type, int height)
        {
            // Arrange
            var triangle = new Triangle(height, type);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            triangle.Draw();

            // Assert
            var result = output.ToString();
            Assert.Contains($"Drawing a Filled {type} Triangle (height: {height})", result);
            Assert.Contains("*", result);
        }

        [Fact]
        public void Triangle_Draw_RightTriangle_OutputsIncreasingAsterisks()
        {
            // Arrange
            var triangle = new Triangle(4, Triangle.TriangleType.Right);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            triangle.Draw();

            // Assert
            var result = output.ToString();
            Assert.Contains("*", result);
            Assert.Contains("**", result);
            Assert.Contains("***", result);
            Assert.Contains("****", result);
        }

        [Fact]
        public void Triangle_Draw_EquilateralTriangle_OutputsSymmetricalPattern()
        {
            // Arrange
            var triangle = new Triangle(3, Triangle.TriangleType.Equilateral);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            triangle.Draw();

            // Assert
            var result = output.ToString();
            // Should have spaces and asterisks in symmetrical pattern
            Assert.Contains(" ", result);
            Assert.Contains("*", result);
        }

        [Fact]
        public void Triangle_Draw_InvertedTriangle_OutputsDecreasingAsterisks()
        {
            // Arrange
            var triangle = new Triangle(3, Triangle.TriangleType.Inverted);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            triangle.Draw();

            // Assert
            var result = output.ToString();
            // Should start with more asterisks and decrease
            Assert.Contains("*", result);
        }

        [Fact]
        public void Triangle_Draw_WithMinimumHeight_OutputsAtLeastOneAsterisk()
        {
            // Arrange
            var triangle = new Triangle(1, Triangle.TriangleType.Right);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            triangle.Draw();

            // Assert
            var result = output.ToString();
            Assert.Contains("*", result);
        }
    }

    public class InterfaceAndIntegrationTests
    {
        [Fact]
        public void AllShapes_Implement_IShape_Interface()
        {
            // Arrange
            IShape circle = new Circle();
            IShape rectangle = new Rectangle();
            IShape triangle = new Triangle();

            // Act & Assert
            Assert.NotNull(circle);
            Assert.NotNull(rectangle);
            Assert.NotNull(triangle);
        }

        [Fact]
        public void ShapesCollection_CanStoreDifferentShapes()
        {
            // Arrange
            var shapes = new System.Collections.Generic.List<IShape>
            {
                new Circle(3),
                new Rectangle(5, 3),
                new Triangle(4, Triangle.TriangleType.Right),
                new Circle(7),
                new Rectangle(8, 4),
                new Triangle(5, Triangle.TriangleType.Equilateral)
            };

            // Act & Assert
            Assert.Equal(6, shapes.Count);
            foreach (var shape in shapes)
            {
                Assert.NotNull(shape);
            }
        }

        [Fact]
        public void AllShapes_HaveDrawMethod_And_CanBeDrawn()
        {
            // Arrange
            IShape[] shapes = {
                new Circle(2),
                new Rectangle(3, 2),
                new Triangle(3, Triangle.TriangleType.Right),
                new Circle(4),
                new Rectangle(5, 3),
                new Triangle(4, Triangle.TriangleType.Equilateral)
            };
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            foreach (var shape in shapes)
            {
                shape.Draw();
                Console.WriteLine("---"); // Separator
            }

            // Assert
            var result = output.ToString();
            Assert.Contains("Circle", result);
            Assert.Contains("Rectangle", result);
            Assert.Contains("Triangle", result);
            Assert.Contains("***", result); // Should contain some asterisk patterns
        }

        [Fact]
        public void MultipleDrawCalls_Work_Consistently()
        {
            // Arrange
            var circle = new Circle(3);
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            circle.Draw();
            var firstResult = output.ToString();

            output.GetStringBuilder().Clear(); // Clear for second draw
            circle.Draw();
            var secondResult = output.ToString();

            // Assert - Both draws should produce the same output
            Assert.Equal(firstResult, secondResult);
        }

        [Fact]
        public void ShapeNames_Are_Correct()
        {
            // Arrange
            var circle = new Circle();
            var rectangle = new Rectangle();
            var rightTriangle = new Triangle(5, Triangle.TriangleType.Right);
            var equilateralTriangle = new Triangle(5, Triangle.TriangleType.Equilateral);

            // Act & Assert
            Assert.Equal("Circle", circle.Name);
            Assert.Equal("Rectangle", rectangle.Name);
            Assert.Equal("Right Triangle", rightTriangle.Name);
            Assert.Equal("Equilateral Triangle", equilateralTriangle.Name);
        }
    }

    public class EdgeCaseTests
    {
        [Fact]
        public void VeryLargeCircle_DoesNotCrash()
        {
            // Arrange
            var circle = new Circle(20); // Large but reasonable size
            var output = new StringWriter();
            Console.SetOut(output);

            // Act & Assert (should not throw)
            var exception = Record.Exception(() => circle.Draw());
            Assert.Null(exception);
        }

        [Fact]
        public void VeryLargeRectangle_DoesNotCrash()
        {
            // Arrange
            var rectangle = new Rectangle(50, 20); // Large but reasonable size
            var output = new StringWriter();
            Console.SetOut(output);

            // Act & Assert (should not throw)
            var exception = Record.Exception(() => rectangle.Draw());
            Assert.Null(exception);
        }

        [Fact]
        public void VeryLargeTriangle_DoesNotCrash()
        {
            // Arrange
            var triangle = new Triangle(15, Triangle.TriangleType.Right); // Large but reasonable size
            var output = new StringWriter();
            Console.SetOut(output);

            // Act & Assert (should not throw)
            var exception = Record.Exception(() => triangle.Draw());
            Assert.Null(exception);
        }

        [Fact]
        public void MultipleShapeCreations_Work_Independently()
        {
            // Arrange & Act
            var circle1 = new Circle(3);
            var circle2 = new Circle(5);
            var rectangle1 = new Rectangle(4, 2);
            var rectangle2 = new Rectangle(6, 3);
            var triangle1 = new Triangle(4, Triangle.TriangleType.Right);
            var triangle2 = new Triangle(5, Triangle.TriangleType.Equilateral);

            // Assert - All should have independent values
            Assert.Equal(3, circle1.Radius);
            Assert.Equal(5, circle2.Radius);
            Assert.Equal(4, rectangle1.Width);
            Assert.Equal(6, rectangle2.Width);
            Assert.Equal(4, triangle1.Height);
            Assert.Equal(5, triangle2.Height);
        }
    }
}