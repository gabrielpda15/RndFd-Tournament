using Microsoft.AspNetCore.Mvc;
using RFT.Api.Controllers.Base;
using RFT.Api.Interfaces;
using RFT.Api.Repository;
using RFT.Api.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RFT.Api.Controllers
{
    public class UserController : Base.CrudController<User>
    {
        public UserController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
