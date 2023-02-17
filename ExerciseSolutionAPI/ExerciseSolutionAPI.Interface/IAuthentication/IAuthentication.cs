using Microsoft.AspNetCore.Http;

namespace ExerciseSolutionAPI.Interface.IAuthentication
{
    public interface IAuthentication
    {
        bool IsRequestValidated(HttpContext context);
    }
}
