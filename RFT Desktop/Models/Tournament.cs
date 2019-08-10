using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Repository.Models
{
    public class Tournament : Base.BaseEntity
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public PlayerTournament[] PlayerTournaments { get; set; }
    }
}
