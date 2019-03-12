using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace WebApiQuiz.Repository{
   public  class Authendication : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public Authendication(IOptionsMonitor<AuthenticationSchemeOptions> options, 
                    ILoggerFactory logger,
                    UrlEncoder encoder, 
                    ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            Console.WriteLine("++++++++++++++" + Request.Headers["Authorization"]);
            if(!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("No key");

           try 
            {
                //var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                //var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                //var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                Console.WriteLine("++++++++++++++" + Request.Headers["Authorization"]);
                var credentials =  Request.Headers["Authorization"].ToString().Split('~');
                var username = credentials[0];
                var password = credentials[1];
                //user = await _userService.Authenticate(username, password);
                //if (username != "AUG" || password!="8x")
                  // return AuthenticateResult.Fail("Invalid Username or Password");
            } 
            catch 
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            

            var claims = new[] { 
                new Claim(ClaimTypes.NameIdentifier, ("AUG").ToString()),
                new Claim(ClaimTypes.Name, "8x"),
            };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);       

            return AuthenticateResult.Success(ticket);
            
        }
    }
}