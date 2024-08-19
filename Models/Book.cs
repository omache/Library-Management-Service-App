using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Year of Publishing")]
        [DisplayFormat(DataFormatString ="{0:yyyy}")]
        public DateTime PublishYear { get; set; }
    }
}