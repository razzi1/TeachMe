using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace MediaDataLayer.Entities
{
    public class ContentPage : IHaveId
    {
        [Key]
        public int Id { get; set; }
        public int MediaId { get; set; }
        public string Content { get; set; }
        public string Sequence { get; set; }
    }
}
