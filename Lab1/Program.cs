namespace Lab1
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter side a: ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Enter side b: ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Enter side c: ");
            double c = double.Parse(Console.ReadLine());

            if (!Triangle.AreSidesPositive(a, b, c))
            {
                Console.WriteLine("All sides must be positive numbers.");
                return;
            }

            Console.WriteLine("All sides are positive.");

            if (!Triangle.IsValid(a, b, c))
            {
                Console.WriteLine("Triangle with such sides does not exist.");
                return;
            }

            Console.WriteLine("Triangle exists.");

            double perimeter = Triangle.CalculatePerimeter(a, b, c);
            Console.WriteLine($"Triangle perimeter: {perimeter}");

            double area = Triangle.CalculateArea(a, b, c);
            Console.WriteLine($"Triangle area: {area:F2}");

            Triangle.DetermineTriangleType(a, b, c);

            if (Triangle.IsRightTriangle(a, b, c))
            {
                Console.WriteLine("Right-angled triangle.");
            }
        }
    }
}
