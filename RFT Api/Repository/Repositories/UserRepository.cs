using RFT.Api.Interfaces.Base;
using RFT.Api.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Repository.Repositories
{
    public class UserRepository : RepositoryBase<User, RFTContext>
    {
        public UserRepository(RFTContext context) : base(context) { }
    }
}
