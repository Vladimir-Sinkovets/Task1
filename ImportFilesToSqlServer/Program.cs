using ImportFilesToSqlServer.Models;

namespace ImportFilesToSqlServer
{
    internal class Program
    {
        private const string filePath = "C:\\Users\\vsink\\OneDrive\\Рабочий стол\\files\\file_0.txt";

        static void Main(string[] args)
        {
            var context = new ApplicationDbContext();
            var importer = new FileImporter(context);

            int left1 = 0;
            int top1 = 0;

            int left2 = 0;
            int top2 = 0;

            importer.OnImportStarted = () => {
                Console.Write("done : ");
                left1 = Console.CursorLeft;
                top1 = Console.CursorTop;

                Console.WriteLine();

                Console.Write("left to load : ");
                left2 = Console.CursorLeft;
                top2 = Console.CursorTop;
            };

            importer.OnImportNextLine = (allLinesCount, loadedLinesCount) =>
            {
                Console.SetCursorPosition(left1, top1);
                Console.Write(loadedLinesCount);

                Console.SetCursorPosition(left2, top2);
                Console.Write($"{allLinesCount - loadedLinesCount}    ");
            };

            importer.ImportTextFileToSql(filePath);
        }
    }
}