using RFT.Api.Repository.Models;
using RFT.Api.Repository.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFT_Desktop.Models
{
    public class PostRequest<TEntity> where TEntity : BaseEntity
    {
        public User User { get; set; }
        public TEntity Entity { get; set; }
    }
}
