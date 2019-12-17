using MicroBank.Transfer.Application.Interfaces;
using MicroBank.Transfer.Domain.Interfaces;
using MicroBank.Transfer.Domain.Models;
using MicroBank.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBank.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _bus;

        public TransferService(ITransferRepository transferRepository, IEventBus bus)
        {
            _transferRepository = transferRepository;
            _bus = bus;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs();
        }
    }
}
