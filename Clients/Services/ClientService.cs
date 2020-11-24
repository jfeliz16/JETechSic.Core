using JETech.NetCoreWeb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JETech.SIC.Core.Clients.Models;
using System.Linq;
using JETech.SIC.Core.Clients.Interfaces;

namespace JETech.SIC.Core.Clients.Services
{
    public class ClientService : IClientService
    {
        public async Task<ActionPaginationResult<IQueryable<ClientModel>>> GetClients(ActionQueryArgs<ClientModel> args)
        {
            try
            {
                Domain.Client client = new Domain.Client();

                return await client.GetClients(args);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
