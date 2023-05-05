using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Models.ViewVM
{
    public class CardVM
    {
        public Card Card { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> AccountType { get; set; }
    }
}
