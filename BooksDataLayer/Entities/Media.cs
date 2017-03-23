using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediaDataLayer.Entities;
using Repository;

namespace MediaDataLayer.Entities
{
    public class Media : IHaveId
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
        public List<Chapter> Chapters { get; set; }
        public string ContentLocation { get; set; }
        public int YearPublished { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public MediaLevel Level { get; set; }
        public int Pages { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public List<Author> Authors { get; set; }
        public string Keywords { get; set; }
        public List<Category> Categories { get; set; }
        public bool IsPartOfACollection { get; set; }
        public int? MediaCollectionId { get; set; }
        public MediaCollection MediaCollection { get; set; }
    }

    public enum MediaType
    {
        Text,
        Html,
        Image,
        Video
    }
}
