using Banking.DataAccess.Data;
using Banking.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public IAccountTypeRepository accountTypeRepository { get; private set; }
        public ICardRepository cardRepository { get; private set; }
        public IApplicationUserTypeRepository applicationUser { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            this.accountTypeRepository = new AccountTypeRepository(_db);
            this.cardRepository = new CardRepository(_db);
            this.applicationUser = new ApplicationUserRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
