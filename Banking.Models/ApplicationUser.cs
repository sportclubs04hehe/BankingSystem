//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;
//using Microsoft.AspNet.Identity.EntityFramework;
//using System.Reflection;

//namespace Banking.Models
//{
//    public class ApplicationUser : IdentityUser {
//        [Required]
//        public string Name { get; set; }
//        [Phone(ErrorMessage = "Please enter a valid phone number."),Display(Name = "Phone Number")]
//        public string? PhoneNumber { get; set; }

//        [Column(TypeName = "decimal(18,2)")]
//        [Range(0, 9999999999999999.99, ErrorMessage = "The {0} field must be between {1} and {2}.")]
//        public decimal? Balance { get; set; }

//        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 5)]
//        public string? Address { get; set; }

//        public string? State { get; set; }

//        public bool? IsAccountLocked { get; set; }  

//        [Range(0, int.MaxValue, ErrorMessage = "The {0} field must be between {1} and {2}.")]
//        public int? InvalidLoginAttempts { get; set; }
//        public string? PostalCode { get; set; }

//        [DataType(DataType.DateTime)]
//        [Display(Name = "Last Login Date")]
//        public DateTime? LastLoginDate { get; set; }
//        public Gender? gender { get; set; }

//        public enum Gender
//        {
//            MALE,
//            FEMALE,
//            OTHER
//        }



//    }
//}
