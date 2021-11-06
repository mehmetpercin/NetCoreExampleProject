using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public interface IDbObject
    {
        public DateTimeOffset CreatedDate { get; set; }
        public int Creator { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public int Modifier { get; set; }
        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
