using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Models
{
    public class AccountType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Account type name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Account type name must be between 2 and 50 characters.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Account type description cannot exceed 500 characters.")]
        public string Description { get; set; }
    }
}
