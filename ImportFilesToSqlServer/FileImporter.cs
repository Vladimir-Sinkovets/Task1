using ImportFilesToSqlServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportFilesToSqlServer
{
    internal class FileImporter
    {
        public Action OnImportStarted;
        public Action<int, int> OnImportNextLine;

        private readonly ApplicationDbContext _context;

        public FileImporter(ApplicationDbContext context)
        {
            _context = context;
        }

        public void ImportTextFileToSql(string filePath)
        {
            OnImportStarted.Invoke();

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

                _context.Entries.Add(entry);

                if (loadedLinesCount % 1000 == 0)
                    _context.SaveChanges();

                loadedLinesCount++;

                OnImportNextLine.Invoke(allLinesCount, loadedLinesCount);
            }
        }
        private IEnumerable<string> ReadFile(string filePath)
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
