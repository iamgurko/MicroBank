using MediatR;
using MicroBank.Banking.Application.Interfaces;
using MicroBank.Banking.Application.Services;
using MicroBank.Banking.Data.Context;
using MicroBank.Banking.Data.Repository;
using MicroBank.Banking.Domain.CommandHandlers;
using MicroBank.Banking.Domain.Commands;
using MicroBank.Banking.Domain.Interfaces;
using MicroBank.Domain.Core.Bus;
using MicroBank.Infra.Bus;
using MicroBank.Transfer.Application.Interfaces;
using MicroBank.Transfer.Application.Services;
using MicroBank.Transfer.Data.Context;
using MicroBank.Transfer.Data.Repository;
using MicroBank.Transfer.Domain.EventHandlers;
using MicroBank.Transfer.Domain.Events;
using MicroBank.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBank.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            //Subscriptions
            services.AddTransient<TransferEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();
        }
    }
}
