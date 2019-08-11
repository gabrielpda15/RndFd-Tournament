using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Repository.Models
{
    [Table("rft_teams")]
    public class Team : Base.BaseEntity
    {
        [StringLength(32)]
        [DataType("varchar")]
        [ScaffoldColumn(false)]
        public string Name { get; set; }

        public int EloPoint { get; set; }

        public int Attempts { get; set; }

        public User Admin { get; set; }

        public TeamPlayer[] TeamPlayers { get; set; }

        public Tournament Tournament { get; set; }
    }
}
