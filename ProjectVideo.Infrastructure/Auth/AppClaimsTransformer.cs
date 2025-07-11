using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ProjectVideo.Infrastructure.Data;
using ProjectVideo.Infrastructure.Data.Entities;
using System.Security.Claims;

namespace ProjectVideo.Infrastructure.Auth
{
    /// <summary>
    /// Adds claims from the application database to the identity object created from the user's windows machine.
    /// </summary>
    public class AppClaimsTransformer : IClaimsTransformation
    {
        private readonly ProjectVideoDbContext _repo;

        public AppClaimsTransformer(ProjectVideoDbContext dbContext)
        {
            _repo = dbContext;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            ClaimsPrincipal clonedPrincipal = principal.Clone();
            if (clonedPrincipal.Identity != null)
            {
                ClaimsIdentity identity = (ClaimsIdentity)clonedPrincipal.Identity;
                Claim? nameClaim = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);

                if (nameClaim != null)
                {
                    string username = nameClaim.Value;
                    User? user = await _repo.Users
                        .Include(x => x.Roles)
                        .FirstOrDefaultAsync(x => x.UserName == username);

                    AddUserClaims(identity, user);
                }
            }

            return clonedPrincipal;
        }

        private void AddUserClaims(ClaimsIdentity identity, User? user)
        {
            if (user != null)
            {
                foreach (Role role in user.Roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
                }

                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserId.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            }
        }
    }
}
