// Triangle.cs
using System.Xml.Linq;

namespace IShape
{
    /// <summary>
    /// Represents a triangle shape with configurable type and height
    /// </summary>
    public class Triangle : ShapeBase
    {
        private int _height;
        private TriangleType _type;

        /// <summary>
        /// Enumeration of supported triangle types
        /// </summary>
        public enum TriangleType
        {
            Right,
            Equilateral,
            Isosceles,
            Inverted
        }

        /// <summary>
        /// Initializes a new Triangle instance
        /// </summary>
        /// <param name="height">Triangle height (default: 6, minimum: 1)</param>
        /// <param name="type">Triangle type (default: Right)</param>
        public Triangle(int height = 6, TriangleType type = TriangleType.Right) : base("Triangle")
        {
            _height = ValidatePositive(height, 6, "Height");
            _type = type;
            _name = $"{type} {_name}";
        }

        /// <summary>
        /// Gets or sets the triangle height
        /// </summary>
        public int Height
        {
            get => _height;
            set
            {
                _height = ValidatePositive(value, 6, "Height");
                _name = $"{_type} Triangle";
            }
        }

        /// <summary>
        /// Gets or sets the triangle type
        /// </summary>
        public TriangleType Type
        {
            get => _type;
            set
            {
                _type = value;
                _name = $"{value} Triangle";
            }
        }

        /// <summary>
        /// Draws the triangle to the console based on its type
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine($"Drawing a Filled {_name} (height: {_height}):");
            Console.WriteLine();

            switch (_type)
            {
                case TriangleType.Right:
                    DrawRightTriangle();
                    break;
                case TriangleType.Equilateral:
                    DrawEquilateralTriangle();
                    break;
                case TriangleType.Isosceles:
                    DrawIsoscelesTriangle();
                    break;
                case TriangleType.Inverted:
                    DrawInvertedTriangle();
                    break;
                default:
                    DrawRightTriangle();
                    break;
            }
        }

        private void DrawRightTriangle()
        {
            for (int i = 1; i <= _height; i++)
            {
                Console.WriteLine(new string('*', i));
            }
        }

        private void DrawEquilateralTriangle()
        {
            for (int i = 0; i < _height; i++)
            {
                Console.Write(new string(' ', _height - i - 1));
                Console.WriteLine(new string('*', 2 * i + 1));
            }
        }

        private void DrawIsoscelesTriangle()
        {
            int baseWidth = _height * 2 - 1;
            for (int i = 0; i < _height; i++)
            {
                int stars = 2 * i + 1;
                int spaces = (baseWidth - stars) / 2;
                Console.Write(new string(' ', spaces));
                Console.WriteLine(new string('*', stars));
            }
        }

        private void DrawInvertedTriangle()
        {
            for (int i = _height; i >= 1; i--)
            {
                int spaces = _height - i;
                Console.Write(new string(' ', spaces));
                Console.WriteLine(new string('*', 2 * i - 1));
            }
        }
    }
}