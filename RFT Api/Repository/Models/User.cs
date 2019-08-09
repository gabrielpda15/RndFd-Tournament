using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Repository.Models
{
    [Table("rft_users")]
    public class User : Base.BaseEntity
    {
        [StringLength(50)]
        [DataType("varchar")]
        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [StringLength(120)]
        [DataType("varchar")]
        [ScaffoldColumn(false)]
        public string PasswordHash { get; set; }

        [ScaffoldColumn(false)]
        public Permission Permission { get; set; }
    }
}
