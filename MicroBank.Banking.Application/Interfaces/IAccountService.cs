using MicroBank.Banking.Application.Models;
using MicroBank.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBank.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransfer accountTransfer);
    }
}
