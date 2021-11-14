using Core.Models;
using System;

namespace Entities.Concrete
{
    public class UserRefreshToken : DbObjectBase<int>
    {
        public int UserId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
