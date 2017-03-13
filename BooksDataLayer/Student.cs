using System.ComponentModel.DataAnnotations;

namespace BooksDataLayer
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public Parent Parent { get; set; }
        public int ParentId { get; set; }
    }
}