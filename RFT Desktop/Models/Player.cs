using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Repository.Models
{
    public class Player : Base.BaseEntity
    {
        public string Name { get; set; }

        public string Nickname { get; set; }

        public Elo Elo { get; set; }

        public Role Roles { get; set; }

        public PlayerTournament[] PlayerTournaments { get; set; }

        public override string ToString()
        {
            return Name + " | " + Nickname;
        }
    }
}
