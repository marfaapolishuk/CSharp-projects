namespace Lb2
{
    internal class StudentGroupAnalyzer
    {
        public int[][] Groups { get; private set; }
        public StudentGroupAnalyzer()
        {
            Random random = new Random();

            int groupCount = random.Next(3, 6);
            Groups = new int[groupCount][];

            for (int i = 0; i < groupCount; i++)
            {
                int studentCount = random.Next(10, 31);
                Groups[i] = new int[studentCount];

                for (int j = 0; j < studentCount; j++)
                {
                    Groups[i][j] = random.Next(60, 101);
                }
            }
        }
        public double GetAverage(int[] groupAVGGrades)
        {
            double sum = 0;
            foreach (int grade in groupAVGGrades)
            {
                sum += grade;
            }
            return sum / groupAVGGrades.Length;
        }

        public int GetMin(int[] minGrades)
        {
            int min = minGrades[0];
            foreach (int grade in minGrades)
            {
                if (grade < min)
                {
                    min = grade;
                }
            }
            return min;
        }

        public int GetMax(int[] maxGrades)
        {
            int max = maxGrades[0];
            foreach (int grade in maxGrades)
            {
                if (grade > max)
                {
                    max = grade;
                }
            }
            return max;
        }

        public double GetTotalAverage(int[][] AllGrades)
        {
            double totalSUM = 0;
            int totalStudents = 0;
            foreach (int[] group in AllGrades)
            {
                totalStudents += group.Length;
                foreach (int grade in group)
                {
                    totalSUM += grade;
                }
            }
            return totalSUM / totalStudents;
        }

        public int GetTotalMin(int[][] totalMIN)
        {
            int absoluteMIN = totalMIN[0][0];
            foreach (int[] group in totalMIN)
            {
                int groupMin = GetMin(group);
                if (groupMin < absoluteMIN)
                {
                    absoluteMIN = groupMin;
                }
            }
            return absoluteMIN;
        }

        public int GetTotalMax(int[][] totalMax)
        {
            int absoluteMAX = totalMax[0][0];
            foreach (int[] group in totalMax)
            {
                int groupMax = GetMax(group);
                if (groupMax > absoluteMAX)
                {
                    absoluteMAX = groupMax;
                }
            }
            return absoluteMAX;

        }
    }
}

