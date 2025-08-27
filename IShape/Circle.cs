using System.Xml.Linq;
namespace IShape
{
    /// <summary>
    /// Represents a circle shape
    /// </summary>
    public class Circle : ShapeBase
    {
        private int _radius;
        /// <summary>
        /// Initializes a new Circle instance
        /// </summary>
        public Circle(int radius = 5) : base("Circle")
        {
            _radius = ValidatePositive(radius, 5, "Radius");
        }
        /// <summary>
        /// Either gets or sets the circle radius
        /// </summary>
        public int Radius
        {
            get => _radius;
            set => _radius = ValidatePositive(value, 5, "Radius");
        }
        /// <summary>
        /// Draws the circle
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine($"Drawing a {Name} (radius: {_radius}):");
            Console.WriteLine();
            /// Logic for making a circle
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