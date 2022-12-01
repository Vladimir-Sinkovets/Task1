using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportFilesToSqlServer.Models
{
    internal class Entry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? LatinText { get; set; }
        public string? RussianText { get; set; }
        public int IntegerNumber { get; set; }
        public double FractionalNumber { get; set; }
    }
}
