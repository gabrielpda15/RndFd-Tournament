using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Repository.Models
{
    public class User : Base.BaseEntity
    {
        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public Permission Permission { get; set; }
    }
}
