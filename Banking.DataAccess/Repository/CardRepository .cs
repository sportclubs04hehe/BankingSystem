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
    public class CardRepository : Repository<Card>, ICardRepository
    {
        private ApplicationDbContext _db;
        public CardRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Card card)
        {
            _db.Update(card);
        }
    }
}
