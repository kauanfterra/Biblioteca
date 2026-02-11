using System;

namespace Biblioteca.Models
{
    public class Member
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }

        public Member(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Name} <{Email}>";
        }
    }
}
