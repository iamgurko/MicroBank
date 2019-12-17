using MicroBank.Banking.Application.Interfaces;
using MicroBank.Banking.Application.Models;
using MicroBank.Banking.Domain.Commands;
using MicroBank.Banking.Domain.Interfaces;
using MicroBank.Banking.Domain.Models;
using MicroBank.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBank.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public AccountService(IAccountRepository accountRepository, IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                    accountTransfer.FromAccount,
                    accountTransfer.ToAccount,
                    accountTransfer.TransferAmount
                );

            _bus.SendCommand(createTransferCommand);
        }
    }
}
