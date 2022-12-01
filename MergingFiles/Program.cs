namespace MergingFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string excludeString = "sfsR";

            string[] allfiles = Directory.GetFiles("C:\\Users\\vsink\\OneDrive\\Рабочий стол\\files");

            StreamWriter writer = new("C:\\Users\\vsink\\OneDrive\\Рабочий стол\\bigFile.txt");

            JoinFiles(excludeString, allfiles, writer);

            writer.Close();
        }

        private static void JoinFiles(string excludeString, string[] allFiles, StreamWriter writer)
        {
            var lines = ReadAllFiles(allFiles);

            int count = 0;

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(excludeString))
                {
                    writer.WriteLine(line);
                }
                else if (line.Contains(excludeString))
                {
                    count++;
                }
                else
                {
                    writer.WriteLine(line);
                }
            }
            Console.WriteLine($"was deleted {count} lines");
        }

        private static IEnumerable<string> ReadAllFiles(string[] allfiles)
        {
            List<string> lines = new();
            
            foreach (string filePath in allfiles)
            {
                lines.AddRange(ReadFile(filePath));
            }

            return lines;
        }

        private static IEnumerable<string> ReadFile(string filePath)
        {
            StreamReader reader = new(filePath);

            string? str;

            while ((str = reader.ReadLine()) != null)
            {
                yield return str;
            }
        }
    }
}