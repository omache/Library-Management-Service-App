using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Borrow
    {
        public int Id { get; set; }
        public string BorrowerName { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime BorrowDate { get; set; }
        public bool IsAproved { get; set; } = false;
        public bool IsReturned {  get; set; } = false;

        internal async Task<string?> ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
