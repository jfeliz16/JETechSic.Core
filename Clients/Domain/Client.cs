using JETech.NetCoreWeb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JETech.SIC.Core.Clients.Models;
using System.Linq;
using JETech.NetCoreWeb.Helper;
using JETech.SIC.Core.Data.Entities;
using JETech.NetCoreWeb.Types;
using JETech.SIC.Core.Global;

namespace JETech.SIC.Core.Clients.Domain
{
    public class Client
    {
        private readonly ActionHelper _actionHelper;
        private readonly SicDbContext _dbContext;

        public Client(SicDbContext sicDb)
        {
            _actionHelper = new ActionHelper();
            _dbContext = sicDb;
        }

        public async Task<ActionResult<ClientModel>> Create(ActionArgs<ClientModel> args) 
        {            
            try
            {
                var cli = new JETech.SIC.Core.Data.Entities.Person
                {
                     Address = args.Model.Address,
                     CellPhone = args.Model.CellPhone,
                     //City= args.Model.City,
                     //Contry = args.Model.CellPhone,
                     Email = args.Model.Email,
                     Fax = args.Model.Fax,
                     FirstName = args.Model.FirstName,
                     FullName = args.Model.FullName,
                     HomePhone = args.Model.HomePhone,
                     IdentityId = args.Model.IdentityId,
                     LastName = args.Model.LastName,
                     Status = new Status { Id = (int)StatusCode.Activo },
                     TypeIdentityId = args.Model.TypeIdentityId,
                     ZipCode = args.Model.ZipCode,
                };

                _dbContext.Persons.Add(cli);

                await _dbContext.SaveChangesAsync();

                args.Model.Id = cli.Id;

                return new ActionResult<ClientModel> { Data = args.Model };       
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ActionPaginationResult<IQueryable<ClientModel>>> Get(ActionQueryArgs<ClientModel> args)
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
                var result = listClient.AsQueryable();
            
                if (args.Condiction != null)
                {
                    result = result.Where(args.Condiction);                    
                }

                return _actionHelper.GetPaginationResult<ClientModel>(args, result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

