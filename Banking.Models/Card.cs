using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Banking.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Balance must be a positive number.")]
        public decimal Balance { get; set; } = 0;

        [Required(ErrorMessage = "Please enter an account number."), Display(Name = "Account Number")]
        [StringLength(19)]
        public string AccountNumber { get; set; }
        public bool IsLocked { get; set; } = false;
        public DateTime DateOpen { get; set; }
        public string? ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId"),ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "Account Type"),Required]     
        public int AccountTypeId { get; set; }
        [ForeignKey("AccountTypeId"),ValidateNever]
        public AccountType AccountType { get; set; }
    }
}
