using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace Core.Helpers
{
    public static class UserHelper
    {

        private static IHttpContextAccessor _httpContextAccessor;
        public static void SetHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static int GetCurrentUser()
        {
            if (_httpContextAccessor == null)
                return -1;

            var value = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id");
            if (value == null)
                return -1;

            return Convert.ToInt32(value.Value);
        }
    }
}
