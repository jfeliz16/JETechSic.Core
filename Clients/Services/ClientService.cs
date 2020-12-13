using JETech.NetCoreWeb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JETech.SIC.Core.Clients.Models;
using System.Linq;
using JETech.SIC.Core.Clients.Interfaces;
using JETech.SIC.Core.Data.Entities;

namespace JETech.SIC.Core.Clients.Services
{
    public class ClientService : IClientService
    {
        private readonly SicDbContext _dbContext;
        private readonly Domain.Client _client;

        public ClientService(SicDbContext dbContext) {
            _dbContext = dbContext;
            _client = new Domain.Client(dbContext);
        }

        public async Task<ActionPaginationResult<IQueryable<ClientModel>>> GetClients(ActionQueryArgs<ClientModel> args)
        {
            try
            {
                return await _client.GetClients(args);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
