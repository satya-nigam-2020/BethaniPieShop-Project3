using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BethanyPieShop2.Models
{
    public class AddressUser
    {
        [Key]
        //[Column(Order = 1)]
        public int Address1Id { get; set; }
        [Required(ErrorMessage ="Atleast one Address required!")]
        [MaxLength(70)]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public Register Register { get; set; }
        public bool Status { get; set; }
        //[Key]
        //[Column(Order = 0)]
        public int UserId { get; set; }
    }
}