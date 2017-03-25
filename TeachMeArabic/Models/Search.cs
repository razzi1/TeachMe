namespace TeachMeArabic.Models
{
    public class Search
    {
        public bool GetCountOnly { get; set; }
        public string SelectedLanguage { get; set; }
        public string SelectedCategory { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Keywords { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
