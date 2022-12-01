namespace CreateFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var original = "C:\\Users\\vsink\\OneDrive\\Рабочий стол\\files";

            var exePath = AppDomain.CurrentDomain.BaseDirectory;

            var path = Path.Combine(exePath, "Files\\");

            Console.WriteLine(path);

            FileCreator fileCreator = new();

            fileCreator.Create(path, 100);
        }
    }
}