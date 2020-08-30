using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BethanyPieShop2.Models
{
    public class Address
    {
        [Key]
        public string FName { get; set; }
        [Required(ErrorMessage = "FName is required")]
        [StringLength(20, ErrorMessage = "Minimum 3 and Maximum 20 characters required", MinimumLength = 3)]
        public string LName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public long Zipcode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [Required(ErrorMessage = "PhoneNo is required")]
        [RegularExpression(@"\+91[0-9]{10}", ErrorMessage = "Invalid Number")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "EmailId is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        public Register Register { get; set; }
        public int UserId { get; set; }
    }
}