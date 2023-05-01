using Banking.DataAccess.Data;
using Banking.DataAccess.Repository.IRepository;
using Banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.DataAccess.Repository
{
    public class AccountTypeRepository : Repository<AccountType>, IAccountTypeRepository
    {
        private ApplicationDbContext _db;
        public AccountTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(AccountType accountType)
        {
            _db.Update(accountType);
        }
    }
}
