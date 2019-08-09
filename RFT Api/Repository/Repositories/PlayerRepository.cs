using RFT.Api.Interfaces.Base;
using RFT.Api.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Repository.Repositories
{
    public class PlayerRepository : RepositoryBase<Player, RFTContext>
    {
        public PlayerRepository(RFTContext context) : base(context) { }
    }
}
