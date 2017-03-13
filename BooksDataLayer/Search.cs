using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDataLayer
{
    public class Search
    {
        public string SelectedLanguage { get; set; }
        public string SelectedBookType { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Keywords { get; set; }
    }
}
