using MediaDataLayer.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeachMeArabic.Models
{
    public class MediaModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
        public bool IsFree { get; set; }
        public decimal Price { get; set; }
        public MediaType MediaType { get; set; }
        public List<ContentPage> ContentPages { get; set; }
        public string ContentLocation { get; set; }
        public int YearPublished { get; set; }
        public Publisher Publisher { get; set; }
        public string Level;
        public int Pages { get; set; }
        public Language Language { get; set; }
        public List<Author> Authors { get; set; }
        public List<string> Keywords { get; set; }
        public List<Category> MediaCategories { get; set; }
        public bool IsPartOfACollection { get; set; }
        public MediaCollection MediaCollection { get; set; }
    }
}
