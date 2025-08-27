// ShapeBase.cs
namespace IShape
{
    /// <summary>
    /// Abstract base class for all shapes providing common functionality
    /// </summary>
    public abstract class ShapeBase : IShape
    {
        protected string _name;

        /// <summary>
        /// Name of the shape
        /// </summary>
        public string Name
        {
            get => _name;
            protected set => _name = value;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        protected ShapeBase(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Abstract method to draw the shape - must be implemented by derived classes
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// Validates if a value is positive, returns default if not
        /// </summary>
        protected int ValidatePositive(int value, int defaultValue, string valueName)
        {
            if (value <= 0)
            {
                Console.WriteLine($"Warning: {valueName} must be positive. Using default value: {defaultValue}");
                return defaultValue;
            }
            return value;
        }
    }
}