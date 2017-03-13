using System.Collections.Generic;

namespace BooksDataLayer
{
    public class Parent
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public List<Student> Children { get; set; }

    }
}