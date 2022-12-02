namespace MergingFiles
{
    internal class FileJoiner
    {
        public void MergeFilesWithExclusion(string[] allFiles, string? excludeString, out int excludedLinesCount)
        {
            excludedLinesCount = 0;

            using StreamWriter writer = new("bigFile.txt");

            var lines = ReadAllFiles(allFiles);

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(excludeString) || !line.Contains(excludeString))
                {
                    writer.WriteLine(line);
                }
                else
                {
                    excludedLinesCount++;
                }
            }
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

            while (!string.IsNullOrEmpty(str = reader.ReadLine()))
            {
                yield return str;
            }
        }
    }
}
