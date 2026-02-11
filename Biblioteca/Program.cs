using System;
using Biblioteca.Models;

// Demo de funcionamento simples da biblioteca
var library = new Library();

// adicionar livros
library.AddBook(new Book("1984", "George Orwell", "9780451524935"));
library.AddBook(new Book("O Senhor dos Anéis", "J.R.R. Tolkien", "9780261102385"));

// registrar usuario
var member = library.RegisterMember("João Silva", "joao@example.com");

// emprestar um livro
var book = library.SearchByTitle("1984");
if (book != null)
{
    var loan = library.BorrowBook(member.Id, book.Id);
    Console.WriteLine($"Empréstimo criado: {loan}");
}

Console.WriteLine("Livros disponíveis:");
foreach (var b in library.ListAvailableBooks())
{
    Console.WriteLine(b);
}

// listar emprestimos do usuario
Console.WriteLine($"\nEmpréstimos de {member.Name}:");
foreach (var l in library.GetLoansForMember(member.Id))
{
    Console.WriteLine(l);
}
