using ExerciseSolutionAPI.Interface.IAuthentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ExerciseSolutionAPI.Service.Authentication
{
    public class AuthenticationService : IAuthentication
    {
        #region Fields
        private readonly IConfiguration configuration;
        private readonly ILogger<AuthenticationService> logger;
        #endregion

        #region Constructor
        public AuthenticationService(IConfiguration configuration, ILogger<AuthenticationService> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }
        #endregion

        #region to validate the request
        /// <summary>
        /// to verify the api token
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool IsRequestValidated(HttpContext context)
        {
            bool isAuthorized = false;
            // check if header has authorization key
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                string authorizationKey = context.Request.Headers["Authorization"].ToString();
                // to verify the authentication token
                logger.LogInformation($"Authorization Key {authorizationKey}");
                isAuthorized = authorizationKey == configuration["TokenKey"];
            }
            return isAuthorized;
        }
        #endregion
    }
}
