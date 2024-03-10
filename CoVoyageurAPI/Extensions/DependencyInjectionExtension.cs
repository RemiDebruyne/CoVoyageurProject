using CoVoyageurAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Security.Claims;

namespace CoVoyageurAPI.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void InjectDependencies(this WebApplicationBuilder builder)
        {
            builder.AddAuthentication();
        }

        public static void AddAuthentication(this WebApplicationBuilder builder)
        {
            var appSettingSection = builder.Configuration.GetSection(nameof(AppSettings));
            builder.Services.Configure<AppSettings>(appSettingSection); // Lie les paramètres de configuration
            AppSettings appSettings = appSettingSection.Get<AppSettings>(); // Récupère les paramètres de configuration

            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey); // Convertit la clé secrète pour la signature

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateAudience = true,
                ValidAudience = appSettings.ValidAudience,
                ValidateIssuer = true,
                ValidIssuer = appSettings.ValidIssuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero

            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(Constants.PolicyAdmin, policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, Constants.RoleAdmin);
                });

                options.AddPolicy(Constants.PolicyUser, policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, Constants.RoleUser);
                });
            });
        }
    }
}
