using RFT.Api.Repository;
using RFT.Api.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Controllers
{
    public class UserController : Base.CrudController<User>
    {
        public UserController(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
