using System.Text;

namespace CreateFiles
{
    internal class FileCreator
    {
        private readonly Random random = new();

        private readonly DateTime start = new(DateTime.Today.Year - 5, DateTime.Today.Month, DateTime.Today.Day);

        public void Create(string targetFolderPath, int count = 100)
        {
            Directory.CreateDirectory(targetFolderPath);

            for (int i = 0; i < count; i++)
            {
                StringBuilder stringBuilder = new();

                using StreamWriter writer = new(Path.Combine(targetFolderPath, $"file_{i}.txt"));
                
                for (int j = 0; j < 100000; j++)
                {
                    AddRandomLine(stringBuilder);
                }

                writer.Write(stringBuilder);
            }
        }

        private void AddRandomLine(StringBuilder stringBuilder)
        {
            AddDate(stringBuilder);

            AddLatinString(stringBuilder);

            AddRussianString(stringBuilder);

            AddInteger(stringBuilder);

            AddDouble(stringBuilder);

            stringBuilder.Append('\n');
        }

        private void AddDate(StringBuilder stringBuilder)
        {
            int daysRange = (DateTime.Today - start).Days;

            DateTime randomDate = start.AddDays(random.Next(daysRange));

            stringBuilder.Append(randomDate.ToString("dd.MM.yy"));

            stringBuilder.Append("||");
        }

        private void AddInteger(StringBuilder stringBuilder)
        {
            int num = random.Next(1, 50000000);

            int evenNum = num * 2;

            stringBuilder.Append(evenNum);

            stringBuilder.Append("||");
        }

        private void AddDouble(StringBuilder stringBuilder)
        {
            double randomDouble = random.NextDouble();

            double num = (randomDouble < 0.999999999) ? randomDouble * 19 + 1 : 20;

            double roundedNum = Math.Round(num, 8);

            stringBuilder.Append(roundedNum);

            stringBuilder.Append("||");
        }

        private void AddLatinString(StringBuilder stringBuilder)
        {
            for (int i = 0; i < 10; i++)
            {
                char nextSymb = random.Next(0, 2) == 0 ? (char)random.Next(65, 91) : (char)random.Next(97, 123);

                stringBuilder.Append(nextSymb);
            }

            stringBuilder.Append("||");
        }

        private void AddRussianString(StringBuilder stringBuilder)
        {
            for (int i = 0; i < 10; i++)
            {
                char nextSymb = (char)random.Next(1040, 1103);

                stringBuilder.Append(nextSymb);
            }

            stringBuilder.Append("||");
        }
    }
}
