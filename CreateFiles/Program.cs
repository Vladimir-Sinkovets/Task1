namespace CreateFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files\\");

            FileCreator fileCreator = new();

            fileCreator.Create(path, 100);
        }
    }
}