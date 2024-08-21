using System.ComponentModel.DataAnnotations;
using System;
using System.Globalization;

namespace LMS.Models
{

    public class Borrow
    {
        public int? Id { get; set; }
        [Display(Name = "Name of Borrower")]
        public string? BorrowerName { get; set; }
        public string? Title { get; set; }
        public int? Quantity { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Borrowing")]
        public DateTime BorrowDate { get; set; }
        [Display(Name = "Approved?")]
        public bool? IsAproved { get; set; } = false;
        [Display(Name = "Returned?")]
        public bool? IsReturned { get; set; } = false;
        public int BorrowPeriod
        {
            get
            {

                TimeSpan duration = DateTime.Now - BorrowDate;
                double output = duration.TotalHours;
                int numberOfHours = (int)output;
                return numberOfHours;
            }
        }

        public int OverDuePeriod
        {
            get
            {
                return BorrowPeriod - 10;
            }
        }

        [DisplayFormat(DataFormatString ="{0:C}", ApplyFormatInEditMode =false)]
        public string OverDueCharges
        {
            get
            {
                CultureInfo kenyanCulture = new CultureInfo("en-KE");

                double amount =  OverDuePeriod * 12.50;
                return amount.ToString("C", kenyanCulture);
            }
        }
        

    }
}
