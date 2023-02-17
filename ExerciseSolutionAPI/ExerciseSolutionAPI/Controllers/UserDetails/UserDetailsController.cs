using ExerciseSolutionAPI.Interface.IUserDetails;
using ExerciseSolutionAPI.Repository.Users;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ExerciseSolutionAPI.Controllers.UserDetails
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ApplicationCorsPolicy")]
    public class UserDetailsController : BaseController
    {
        #region Fields
        private readonly ILogger<UserDetailsController> logger;
        private readonly IUserDetails userDetailsService;
        #endregion

        #region Constructor
        public UserDetailsController(ILogger<UserDetailsController> logger, IUserDetails userDetailsService)
        {
            this.logger = logger;
            this.userDetailsService = userDetailsService;
        }
        #endregion

        #region To create the user details
        /// <summary>
        /// to create the user details
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateUserDetails")]
        public async Task<IActionResult> CreateUserDetails(User user)
        {
            try
            {
                var isSuccess = await userDetailsService.CreateUserDetailsAsync(user);
                return isSuccess ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error Occured : {ex.Message}");
                return BadRequest();
            }
        }
        #endregion

        #region To get all the user details
        /// <summary>
        /// to get all the user details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUserDetails")]
        public async Task<IActionResult> GetUserDetails()
        {
            try
            {
                var userDetails = await userDetailsService.GetUserDetailsAsync();
                return Ok(userDetails);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error Occured : {ex.Message}");
                return BadRequest();
            }
        }
        #endregion

        #region To update the user details
        /// <summary>
        /// to update the user details
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateUserDetails")]
        public async Task<IActionResult> UpdateUserDetails(User user)
        {
            try
            {
                var isSucess = await userDetailsService.UpdateUserDetailsAsync(user);
                return isSucess ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error Occured : {ex.Message}");
                return BadRequest();
            }
        }
        #endregion

        #region To delete the user details
        /// <summary>
        /// to delete the user details
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("DeleteUserDetails")]
        public async Task<IActionResult> DeleteUserDetails(User user)
        {
            try
            {
                var isSuccess = await userDetailsService.DeleteUserDetailsAsync(user);
                return isSuccess ? Ok() : BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error Occured : {ex.Message}");
                return BadRequest();
            }
        }
        #endregion
    }
}
