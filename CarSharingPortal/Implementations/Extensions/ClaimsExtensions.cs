using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarSharingPortal.Implementations.Extensions
{
    public static class ClaimsExtensions
    {
        public static string GetUserId(this ClaimsPrincipal model)
        {
            return model.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public static string GetUserName(this ClaimsPrincipal model)
        {
            return model.FindFirstValue(ClaimTypes.Name);
        }

    }
}
