namespace MergingFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files\\");

            Console.WriteLine("Exclude string : ");

            var excludeString = Console.ReadLine();

            var joiner = new FileJoiner();

            string[] allFiles = Directory.GetFiles(path);

            joiner.MergeFilesWithExclusion(allFiles, excludeString, out int excludedLinesCount);


            Console.WriteLine($"{excludedLinesCount} lines were deleted");
        }
    }
}