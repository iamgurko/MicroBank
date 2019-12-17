﻿using MicroBank.Domain.Core.Bus;
using MicroBank.Transfer.Domain.Events;
using MicroBank.Transfer.Domain.Interfaces;
using MicroBank.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroBank.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;

        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            _transferRepository.Add(new TransferLog()
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                TransferAmount = @event.Amount
            });

            return Task.CompletedTask;
        }
    }
}
