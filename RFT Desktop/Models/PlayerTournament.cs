using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Repository.Models
{
    public class PlayerTournament
    {
        public int PlayerId { get; set; }
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }
        public Player Player { get; set; }
    }
}
