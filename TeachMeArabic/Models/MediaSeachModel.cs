using MediaDataLayer.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeachMeArabic.Models
{
    public class MediaSeachModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public MediaType MediaType { get; set; }
        public string Content { get; set; }
        public string ContentLocation { get; set; }
    }
}
