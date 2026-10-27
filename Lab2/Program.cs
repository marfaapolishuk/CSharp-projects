namespace Lb2
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            StudentGroupAnalyzer analyzer = new StudentGroupAnalyzer();
            Console.WriteLine("Оцінки студентів за підгрупами:");
            Console.WriteLine("======================================");
            for (int i = 0; i < analyzer.Groups.Length; i++)
            {
                Console.WriteLine($"Підгрупа {i + 1} (Кількість студентів: {analyzer.Groups[i].Length}):");
                Console.WriteLine(string.Join(", ", analyzer.Groups[i]));
                Console.WriteLine();
            }
            Console.WriteLine("======================================");
            Console.WriteLine("Результати розрахунів для кожної групи");
            for (int i = 0; i < analyzer.Groups.Length; i++)
            {
                double avg = analyzer.GetAverage(analyzer.Groups[i]);
                int min = analyzer.GetMin(analyzer.Groups[i]);
                int max = analyzer.GetMax(analyzer.Groups[i]);

                Console.WriteLine($"   ==Група {i + 1}==");
                Console.WriteLine($"  Середній бал : {avg:F2}");
                Console.WriteLine($"  Мінімальна оцінка: {min}");
                Console.WriteLine($"  Максимальна оцінка: {max}");
            }
            Console.WriteLine("======================================");
            Console.WriteLine("Результати розрахунку для потоку");
            Console.WriteLine($"  Середній бал потоку : {analyzer.GetTotalAverage(analyzer.Groups):F2}");
            Console.WriteLine($"  Мінімальна оцінка потоку: {analyzer.GetTotalMin(analyzer.Groups)}");
            Console.WriteLine($"  Максимальна оцінка потоку: {analyzer.GetTotalMax(analyzer.Groups)}");
        }
    }
}
