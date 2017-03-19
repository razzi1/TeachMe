using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Repository;

namespace MediaDataLayer.Entities
{
    public class Category : IHaveId
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
