using Microsoft.AspNetCore.Mvc;
using RFT.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Controllers.Base
{
    public class CrudController : Controller
    {
        public CrudController(RFTContext context)
        {

        }
    }
}
