namespace ImportFilesToSqlServer
{
    internal class Program
    {
        private static readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "file.txt");

        static void Main(string[] args)
        {
            var importer = new FileImporter();

            int left1 = 0;
            int top1 = 0;

            int left2 = 0;
            int top2 = 0;

            importer.OnImportStarted = () => {
                Console.Write("done : ");
                left1 = Console.CursorLeft;
                top1 = Console.CursorTop;

                Console.WriteLine();

                Console.Write("left : ");
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

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files\\");

            var context = new ApplicationDbContext();

            importer.ImportTextFileToSql(filePath, context);
        }
    }
}