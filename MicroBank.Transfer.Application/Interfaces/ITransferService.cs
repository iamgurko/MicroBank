using MicroBank.Transfer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBank.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
