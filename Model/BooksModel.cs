using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrialBookStore.Model
{
    public class BooksModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}