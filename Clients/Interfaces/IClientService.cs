using JETech.NetCoreWeb;
using JETech.NetCoreWeb.Types;
using JETech.SIC.Core.Clients.Models;
using System.Linq;
using System.Threading.Tasks;

namespace JETech.SIC.Core.Clients.Interfaces
{
    public interface IClientService
    {
        ActionPaginationResult<IQueryable<ClientModel>> GetClients(ActionQueryArgs<ClientModel> args);
    }
}