using System.Collections.Generic;
using Repository;

namespace MediaDataLayer.Entities
{
    public class Parent : IHaveId
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EncryptedPassword { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public List<Student> Children { get; set; }

    }
}