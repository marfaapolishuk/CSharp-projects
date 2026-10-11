namespace Lab1
{
    internal class Triangle
    {
        public static bool AreSidesPositive(double a, double b, double c)
        {
            return a > 0 && b > 0 && c > 0;
        }

        public static bool IsValid(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        public static double CalculatePerimeter(double a, double b, double c)
        {
            return a + b + c;
        }

        public static double CalculateArea(double a, double b, double c)
        {
            double p = CalculatePerimeter(a, b, c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public static void DetermineTriangleType(double a, double b, double c)
        {
            if (a == b && b == c)
            {
                Console.WriteLine("Equilateral triangle.");
            }
            else if (a == b || a == c || b == c)
            {
                Console.WriteLine("Isosceles triangle.");
            }
            else
            {
                Console.WriteLine("Scalene triangle.");
            }
        }

        public static bool IsRightTriangle(double a, double b, double c)
        {
            double max;
            double side1;
            double side2;

            if (a >= b && a >= c)
            {
                max = a;
                side1 = b;
                side2 = c;
            }
            else if (b >= a && b >= c)
            {
                max = b;
                side1 = a;
                side2 = c;
            }
            else
            {
                max = c;
                side1 = a;
                side2 = b;
            }

            return Math.Abs(side1 * side1 + side2 * side2 - max * max) < 0.000001;
        }
    }
}
