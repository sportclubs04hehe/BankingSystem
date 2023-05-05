using Banking.Models;
using Banking.Models.ViewVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.DataAccess.Repository.IRepository
{
    public interface ICardRepository : IRepository<Card>
    {
        void Update(Card card);
    }
}
