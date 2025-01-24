using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace ProductApi.WebAPI.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock) { }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return Task.FromResult(AuthenticateResult.Fail("Cabeçalho de autorização ausente"));

            try
            {
                var authHeader = Request.Headers["Authorization"].ToString();

                if (!authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
                    return Task.FromResult(AuthenticateResult.Fail("Formato inválido no cabeçalho de autorização"));

                var encodedCredentials = authHeader.Substring("Basic ".Length).Trim();
                var decodedCredentials = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredentials));
                var credentials = decodedCredentials.Split(':');

                if (credentials.Length != 2)
                    return Task.FromResult(AuthenticateResult.Fail("Formato inválido no cabeçalho de autorização"));

                var username = credentials[0];
                var password = credentials[1];

                if (username != "admin" || password != "password")
                    return Task.FromResult(AuthenticateResult.Fail("Usuário ou senha inválidos"));

                var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim(ClaimTypes.Name, username)
                };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return Task.FromResult(AuthenticateResult.Success(ticket));
            }
            catch (FormatException)
            {
                return Task.FromResult(AuthenticateResult.Fail("String Base64 inválida no cabeçalho de autorização"));
            }
            catch
            {
                return Task.FromResult(AuthenticateResult.Fail("Erro no cabeçalho de autorização"));
            }
        }
    }
}
