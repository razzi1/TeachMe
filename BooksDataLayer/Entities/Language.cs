﻿using System.ComponentModel.DataAnnotations;
using Repository;

namespace MediaDataLayer.Entities
{
    public class Language : IHaveId
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
