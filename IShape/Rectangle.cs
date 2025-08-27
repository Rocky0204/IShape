// Rectangle.cs
using System.Xml.Linq;

namespace IShape
{
    /// <summary>
    /// Represents a rectangle shape with configurable dimensions
    /// </summary>
    public class Rectangle : ShapeBase
    {
        private int _width;
        private int _height;

        /// <summary>
        /// Initializes a new Rectangle instance
        /// </summary>
        /// <param name="width">Rectangle width (default: 10, minimum: 1)</param>
        /// <param name="height">Rectangle height (default: 5, minimum: 1)</param>
        public Rectangle(int width = 10, int height = 5) : base("Rectangle")
        {
            _width = ValidatePositive(width, 10, "Width");
            _height = ValidatePositive(height, 5, "Height");
        }

        /// <summary>
        /// Gets or sets the rectangle width
        /// </summary>
        public int Width
        {
            get => _width;
            set => _width = ValidatePositive(value, 10, "Width");
        }

        /// <summary>
        /// Gets or sets the rectangle height
        /// </summary>
        public int Height
        {
            get => _height;
            set => _height = ValidatePositive(value, 5, "Height");
        }

        /// <summary>
        /// Draws the filled rectangle to the console
        /// </summary>
        public override void Draw()
        {
            Console.WriteLine($"Drawing a Filled {Name} ({_width}x{_height}):");
            Console.WriteLine();
            DrawFilled();
        }

        private void DrawFilled()
        {
            for (int i = 0; i < _height; i++)
            {
                Console.WriteLine(new string('*', _width));
            }
        }

        /// <summary>
        /// Draws the rectangle with new dimensions
        /// </summary>
        /// <param name="newWidth">New width value</param>
        /// <param name="newHeight">New height value</param>
        public void DrawWithSize(int newWidth, int newHeight)
        {
            _width = ValidatePositive(newWidth, _width, "Width");
            _height = ValidatePositive(newHeight, _height, "Height");
            Draw();
        }
    }
}