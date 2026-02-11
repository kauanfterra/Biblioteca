using System;

namespace Biblioteca.Models
{
    public class Book
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public bool IsAvailable { get; set; } = true;

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
        }

        public override string ToString()
        {
            return $"{Title} - {Author} ({Isbn}) {(IsAvailable ? "[Disponível]" : "[Emprestado]")}";
        }
    }
}
