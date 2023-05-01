using Banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.DataAccess.Repository.IRepository
{
    public interface IAccountTypeRepository : IRepository<AccountType>
    {
        void Update(AccountType accountType);
    }
}
