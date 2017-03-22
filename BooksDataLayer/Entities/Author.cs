using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediaDataLayer.Entities;
using Repository;

namespace MediaDataLayer.Entities
{
    public class Author : IHaveId
    {
        [Key]
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Biography { get; set; }
        public List<Media> MediaList { get; set; }
    }
}