using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Borrow
    {
        public int? Id { get; set; }
        [Display(Name ="Name of Borrower")]
        public string? BorrowerName { get; set; }
        public string? Title { get; set; }
        public int? Quantity { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name ="Date of Borrowing")]
        public DateTime BorrowDate { get; set; }
        [Display(Name ="Approved?")]
        public bool? IsAproved { get; set; } = false;
        [Display(Name = "Returned?")]
        public bool? IsReturned {  get; set; } = false;

    }
}
