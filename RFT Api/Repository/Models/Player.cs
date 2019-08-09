using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Repository.Models
{
    [Table("rft_players")]
    public class Player : Base.BaseEntity
    {
        [StringLength(60)]
        [DataType("varchar")]
        [ScaffoldColumn(false)]
        public string Name { get; set; }

        [StringLength(16)]
        [DataType("varchar")]
        [ScaffoldColumn(false)]
        public string Nickname { get; set; }

        [ScaffoldColumn(false)]
        public Elo Elo { get; set; }

        [ScaffoldColumn(false)]
        public Role Roles { get; set; }

        public PlayerTournament[] PlayerTournaments { get; set; }
    }
}
