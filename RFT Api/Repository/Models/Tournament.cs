using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Repository.Models
{
    [Table("rft_tournament")]
    public class Tournament : Base.BaseEntity
    {
        [StringLength(60)]
        [DataType("varchar")]
        [ScaffoldColumn(false)]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Date { get; set; }

        public PlayerTournament[] PlayerTournaments { get; set; }
    }
}
