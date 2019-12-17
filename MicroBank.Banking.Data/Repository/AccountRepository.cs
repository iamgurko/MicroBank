using MicroBank.Banking.Data.Context;
using MicroBank.Banking.Domain.Interfaces;
using MicroBank.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBank.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private BankingDbContext _ctx;

        public AccountRepository(BankingDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _ctx.Accounts;
        }
    }
}
