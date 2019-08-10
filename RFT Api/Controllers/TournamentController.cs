﻿using RFT.Api.Interfaces;
using RFT.Api.Repository;
using RFT.Api.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Controllers
{
    public class TournamentController : Base.CrudController<Tournament>
    {
        public TournamentController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
