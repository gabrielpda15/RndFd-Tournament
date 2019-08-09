using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace RFT.Api.Interfaces.Security
{
    public interface IUserContext
    {
        IPrincipal Principal { get; set; }

        IEnumerable<string> Roles { get; set; }

        string SelectedRole { get; set; }

        string IP { get; set; }

        string HostName { get; set; }

        string[] Languages { get; set; }

        IEnumerable<string> SelectedRoles { get; set; }

        IDictionary<string, object> Parametros { get; set; }

        IEnumerable<Claim> Claims { get; set; }
    }
}
