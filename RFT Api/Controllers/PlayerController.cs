using RFT.Api.Repository;
using RFT.Api.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Controllers
{
    public class PlayerController : Base.CrudController<Player>
    {
        public PlayerController(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
