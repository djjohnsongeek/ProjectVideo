using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using ProjectVideo.Core.Auth;
using System.Security.Claims;

namespace ProjectVideo.Infrastructure.Auth
{
    public class AppPolicyProvider : IAuthorizationPolicyProvider
    {
        public DefaultAuthorizationPolicyProvider BackupAuthPolicyProvider { get; }
        public Dictionary<string, AuthorizationPolicy> _policies { get; }

        public AppPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            // If this provider cannot find a policy, the default provider will be used.
            BackupAuthPolicyProvider = new DefaultAuthorizationPolicyProvider(options);

            // fallback
            // options.Value.FallbackPolicy = options.Value.DefaultPolicy;

            // Add custom policies
            _policies = new Dictionary<string, AuthorizationPolicy>();

            AuthorizationPolicy coordinatorRequired = new AuthorizationPolicyBuilder().RequireClaim(ClaimTypes.Role, AppRole.Coordinator).Build();
            AuthorizationPolicy adminRequired = new AuthorizationPolicyBuilder().RequireClaim(ClaimTypes.Role, AppRole.Admin).Build();
            AuthorizationPolicy staffRequired = new AuthorizationPolicyBuilder().RequireClaim(ClaimTypes.Role, AppRole.Staff).Build();
            AuthorizationPolicy userRequired = new AuthorizationPolicyBuilder().RequireClaim(ClaimTypes.Role, AppRole.User).Build();

            _policies.Add(AppPolicies.CoordinatorRequired, coordinatorRequired);
            _policies.Add(AppPolicies.StaffRequired, staffRequired);
            _policies.Add(AppPolicies.AdminRequired, adminRequired);
            _policies.Add(AppPolicies.UserRequired, userRequired);
        }

        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            if (_policies.TryGetValue(policyName, out AuthorizationPolicy policy))
            {
                return Task.FromResult(policy);
            }
            else
            {
                return BackupAuthPolicyProvider.GetPolicyAsync(policyName);
            }
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => BackupAuthPolicyProvider.GetDefaultPolicyAsync();
        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() => BackupAuthPolicyProvider.GetFallbackPolicyAsync();
    }
}
