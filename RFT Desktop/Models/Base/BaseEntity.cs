using System;

namespace RFT.Api.Repository.Models.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public string EditionUser { get; set; }

        public DateTime? EditionDate { get; set; }
    }
}
