﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAccountTypeRepository accountTypeRepository { get; }

        void Save();
    }
}
