using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Models
{
    public class Library
    {
        private readonly List<Book> _books = new();
        private readonly List<Member> _members = new();
        private readonly List<Loan> _loans = new();

        public void AddBook(Book book) => _books.Add(book);

        public Member RegisterMember(string name, string email)
        {
            var m = new Member(name, email);
            _members.Add(m);
            return m;
        }

        public Book? SearchByTitle(string title)
        {
            return _books.FirstOrDefault(b => string.Equals(b.Title, title, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Book> ListAvailableBooks() => _books.Where(b => b.IsAvailable).ToList();

        public Loan BorrowBook(Guid memberId, Guid bookId)
        {
            var book = _books.FirstOrDefault(b => b.Id == bookId) ?? throw new InvalidOperationException("Livro não encontrado");
            if (!book.IsAvailable) throw new InvalidOperationException("Livro não está disponível");

            var member = _members.FirstOrDefault(m => m.Id == memberId) ?? throw new InvalidOperationException("Membro não encontrado");

            book.IsAvailable = false;
            var loan = new Loan { BookId = bookId, MemberId = memberId };
            _loans.Add(loan);
            return loan;
        }

        public void ReturnBook(Guid loanId)
        {
            var loan = _loans.FirstOrDefault(l => l.Id == loanId) ?? throw new InvalidOperationException("Empréstimo não encontrado");
            if (loan.IsReturned) throw new InvalidOperationException("Livro já devolvido");

            var book = _books.FirstOrDefault(b => b.Id == loan.BookId) ?? throw new InvalidOperationException("Livro não encontrado");
            book.IsAvailable = true;
            loan.ReturnedAt = DateTime.Now;
        }

        public IEnumerable<Loan> GetLoansForMember(Guid memberId)
        {
            return _loans.Where(l => l.MemberId == memberId).ToList();
        }
    }
}
