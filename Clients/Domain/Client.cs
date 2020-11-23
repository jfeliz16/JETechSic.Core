using JETech.NetCoreWeb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JETech.SIC.Core.Clients.Models;
using System.Linq;
using JETech.NetCoreWeb.Helper;

namespace JETech.SIC.Core.Clients.Domain
{
    public class Client
    {
        private readonly ActionHelper _actionHelper;
        
        public Client() 
        {
            _actionHelper = new ActionHelper();
        }

        public async Task<ActionPaginationResult<IQueryable<Clients.Models.ClientModel>>> GetClients(ActionQueryArgs<ClientModel> args)
        {
            try
            {
                List<ClientModel> listClient = new List<ClientModel>();
                int id = 1;

                for (int i = 0; i < 50; i++)
                {
                    listClient.Add(new ClientModel
                    {
                        Id = id,
                        FullName = "Andrick Lora" + id.ToString().PadLeft(5, '*'),
                        FirstName = "Andrick",
                        LastName = "Lora",
                        StatusName = "ACTIVO"
                    });
                    id += 1;
                }

                return _actionHelper.GetPaginationResult<ClientModel>(args, listClient.AsQueryable());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
