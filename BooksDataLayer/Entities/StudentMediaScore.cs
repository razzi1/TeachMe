using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediaDataLayer.Entities
{
    public class StudentMediaScore
    {
        [Key]
        [Column(Order = 1)]
        public int StudentId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int MediaId { get; set; }
        public Student Student { get; set; }
        public Media Media { get; set; }
        [Key]
        [Column(Order = 3)]
        public DateTime TestUtcDateTime { get; set; }
        public decimal? Score { get; set; }
    }
}