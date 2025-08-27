// Circle.cs
using System.Xml.Linq;

namespace IShape
{
    /// <summary>
    /// Represents a circle shape with configurable radius
    /// </summary>
    public class Circle : ShapeBase
    {
        private int _radius;

        /// <summary>
        /// Initializes a new Circle instance
        /// </summary>
        /// <param name="radius">Circle radius (default: 5, minimum: 1)</param>
        public Circle(int radius = 5) : base("Circle")
        {
            _radius = ValidatePositive(radius, 5, "Radius");
        }

        /// <summary>
        /// Gets or sets the circle radius
        /// </summary>
        public int Radius
        {
            get => _radius;
            set => _radius = ValidatePositive(value, 5, "Radius");
        }

        /// <summary>
        /// Draws the circle to the console using asterisk characters
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine($"Drawing a {Name} (radius: {_radius}):");
            Console.WriteLine();

            int diameter = _radius * 2;
            for (int y = 0; y <= diameter; y++)
            {
                for (int x = 0; x <= diameter; x++)
                {
                    double dx = x - _radius;
                    double dy = y - _radius;
                    double distance = Math.Sqrt(dx * dx + dy * dy);
                    Console.Write(distance <= _radius + 0.5 ? "*" : " ");
                }
                Console.WriteLine();
            }
        }
    }
}