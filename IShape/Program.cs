namespace IShape;
using System;
using System.Collections.Generic;
/// <summary>
/// Main application class demonstrating shape drawing capabilities
/// </summary>
public class Program
{
    /// <summary>
    /// Entry point of the application
    /// </summary>
    static void Main(string[] args)
    {
        try
        {
            DrawAllShapes();
            DemonstrateVariations();
            DemonstrateResizing();
            Console.WriteLine("All shapes drawn successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
        }
    }
    private static void DrawAllShapes()
    {
        Console.WriteLine("Starting to draw shapes:");
        Console.WriteLine("========================");
        List<IShape> shapes = new List<IShape>
        {
            new Circle(),
            new Rectangle(8, 4),
            new Triangle(6, Triangle.TriangleType.Right),
            new Triangle(5, Triangle.TriangleType.Equilateral),
            new Triangle(4, Triangle.TriangleType.Inverted),
            new Triangle(5, Triangle.TriangleType.Isosceles)
        };
        foreach (IShape shape in shapes)
        {
            shape.Draw();
            Console.WriteLine();
        }
    }

    private static void DemonstrateVariations()
    {
        // Different rectangle sizes
        Console.WriteLine("Different rectangle sizes:");
        Console.WriteLine("=========================");
        Rectangle smallRect = new Rectangle(4, 5);
        smallRect.Draw();
        Console.WriteLine();
        Rectangle largeRect = new Rectangle(20, 6);
        largeRect.Draw();
        Console.WriteLine();

        // Different triangle types
        Console.WriteLine("Different triangle types:");
        Console.WriteLine("========================");
        Triangle equilateralTriangle = new Triangle(7, Triangle.TriangleType.Equilateral);
        equilateralTriangle.Draw();
        Console.WriteLine();
        Triangle invertedTriangle = new Triangle(6, Triangle.TriangleType.Inverted);
        invertedTriangle.Draw();
        Console.WriteLine();
        Triangle isoscelesTriangle = new Triangle(9, Triangle.TriangleType.Isosceles);
        isoscelesTriangle.Draw();
        Console.WriteLine();
        Triangle equilateralTriangle2  = new Triangle(7, Triangle.TriangleType.Right);
        equilateralTriangle2.Draw();
        Console.WriteLine();
    }

    private static void DemonstrateResizing()
    {
        // Resizing the rectangle
        Console.WriteLine("Resizing examples:");
        Console.WriteLine("=================");
        Rectangle dynamicRect = new Rectangle(5, 3);
        dynamicRect.Draw();
        Console.WriteLine();
        Console.WriteLine("After resizing:");
        dynamicRect.DrawWithSize(8, 4);
        Console.WriteLine();
    }
}