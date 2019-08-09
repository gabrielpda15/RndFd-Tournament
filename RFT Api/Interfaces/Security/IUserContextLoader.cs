using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Interfaces.Security
{
    public interface IUserContextLoader
    {
        void Save(IUserContext userContext);
        void Load(IUserContext userContext);
    }
}
