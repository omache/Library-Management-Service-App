using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Borrowed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BookDescription { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime BorrowDate { get; set; }
        public bool IsReturned {  get; set; } = false;

    }
}
