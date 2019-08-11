using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Repository.Models
{
    [Table("rft_teamplayers")]
    public class TeamPlayer
    {
        public Team Team { get; set; }
        public int TeamId { get; set; }
        public Player Player { get; set; }
        public int PlayerId { get; set; }
    }
}
