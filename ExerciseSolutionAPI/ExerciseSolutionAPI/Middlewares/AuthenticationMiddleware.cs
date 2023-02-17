using ExerciseSolutionAPI.Interface.IAuthentication;
using ExerciseSolutionAPI.Model.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ExerciseSolutionAPI.Middlewares
{
    public class AuthenticationMiddleware : IMiddleware
    {
        #region Fields
        private readonly ILogger<AuthenticationMiddleware> logger;
        private readonly IAuthentication authenticationService;
        #endregion

        #region Constructor
        public AuthenticationMiddleware(ILogger<AuthenticationMiddleware> logger, IAuthentication authenticationService)
        {
            this.logger = logger;
            this.authenticationService = authenticationService;
        }
        #endregion

        #region to validate the request
        /// <summary>
        /// to verify the authentiation token key
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // to verify the authentication token
            bool isAuthorized = authenticationService.IsRequestValidated(context);

            #region to pass it to the next layer
            logger.LogInformation($"Is Authorized {isAuthorized}");
            // check if the user is authorized
            if (isAuthorized)
            {
                await next(context);
                // check if any error occured
                if (context.Response.StatusCode != (int)StatusCode.Success)
                {
                    logger.LogError($"Error Occured");
                    return;
                }
            }
            else
            {
                context.Response.StatusCode = (int)StatusCode.Unauthorized; // to mark as unauthorized
                await context.Response.WriteAsync("Not Found");
                return;
            }
            #endregion
        }
        #endregion
    }
}
