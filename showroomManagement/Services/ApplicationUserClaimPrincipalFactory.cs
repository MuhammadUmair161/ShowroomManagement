using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using showroomManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace showroomManagement.Services
{
    public class ApplicationUserClaimPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaimPrincipalFactory(UserManager<ApplicationUser> userManager,
            IOptions<IdentityOptions> _option, RoleManager<IdentityRole> roleManager) : base(userManager, roleManager, _option)
        {

        }

        protected async override Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserFullName", user.FullName ?? ""));
            return identity;
        }
    }
}
