using System;

namespace Biblioteca.Models
{
    public class Loan
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid BookId { get; set; }
        public Guid MemberId { get; set; }
        public DateTime BorrowedAt { get; set; } = DateTime.Now;
        public DateTime? ReturnedAt { get; set; }

        public bool IsReturned => ReturnedAt.HasValue;

        public override string ToString()
        {
            return $"Loan {Id} - Book: {BookId} Member: {MemberId} Borrowed: {BorrowedAt} Returned: {(ReturnedAt?.ToString() ?? "-")}";
        }
    }
}
