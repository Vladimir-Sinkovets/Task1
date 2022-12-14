using ImportFilesToSqlServer.Models;

namespace ImportFilesToSqlServer
{
    internal class FileImporter
    {
        public event Action? OnImportStarted;
        public event Action<int, int>? OnImportUpdated;

        public void ImportTextFileToSql(string filePath, ApplicationDbContext context)
        {
            OnImportStarted?.Invoke();

            IEnumerable<string> lines = ReadFile(filePath);

            int allLinesCount = lines.Count();
            int loadedLinesCount = 0;

            foreach (var line in lines)
            {
                string[] elements = line.Split("||");

                var entry = new Entry()
                {
                    Date = DateTime.Parse(elements[0]),
                    LatinText = elements[1],
                    RussianText = elements[2],
                    IntegerNumber = int.Parse(elements[3]),
                    FractionalNumber = double.Parse(elements[4]),
                };

                context.Entries?.Add(entry);

                loadedLinesCount++;

                if (loadedLinesCount % 1000 == 0)
                {
                    context.SaveChanges();
                    OnImportUpdated?.Invoke(allLinesCount, loadedLinesCount);
                }
            }
        }
        private static IEnumerable<string> ReadFile(string filePath)
        {
            StreamReader reader = new(filePath);

            string? str;

            while (!string.IsNullOrEmpty(str = reader.ReadLine()))
            {
                yield return str;
            }
        }
    }
}
