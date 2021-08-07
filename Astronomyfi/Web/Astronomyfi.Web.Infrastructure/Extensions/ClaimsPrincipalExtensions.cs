namespace Astronomyfi.Web.Infrastructure.Extensions
{
    using System.Security.Claims;

    using Astronomyfi.Common;

    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdministrator(this ClaimsPrincipal claimsPrincipal)
          => claimsPrincipal.IsInRole(GlobalConstants.AdministratorRoleName);
    }
}
