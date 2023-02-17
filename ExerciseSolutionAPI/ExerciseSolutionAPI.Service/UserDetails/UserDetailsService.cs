using ExerciseSolutionAPI.Interface.IUserDetails;
using ExerciseSolutionAPI.Repository;
using ExerciseSolutionAPI.Repository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseSolutionAPI.Service.UserDetails
{
    public class UserDetailsService : IUserDetails
    {
        #region Fields
        private readonly AppDbContext model;
        #endregion

        #region Constructor
        public UserDetailsService(AppDbContext model)
        {
            this.model = model;
        }
        #endregion

        #region to create the user details
        /// <summary>
        /// to create the user details
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<bool> CreateUserDetailsAsync(User users)
        {
            // to save the new user
            var userDetails = new User
            {
                DateAdded = DateTime.Now,
                DateModified = DateTime.Now,
                Dob = DateTime.Now,
                Email = users.Email,
                FirstName = users.FirstName,
                LastName = users.LastName,
                MobileNumber = users.MobileNumber,
                IsDeleted = false
            };
            model.Add(userDetails);
            await model.SaveChangesAsync();
            return true;
        }
        #endregion

        #region to delete the user details
        /// <summary>
        /// to delete the user details
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUserDetailsAsync(User users)
        {
            var userDetails = model.Users.Where(x => x.UserId == users.UserId).FirstOrDefault();
            // null check
            if (userDetails != null)
            {
                userDetails.IsDeleted = true;
                model.Update(userDetails);
                await model.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion

        #region to get all the user details
        /// <summary>
        /// to get all the user details
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetUserDetailsAsync()
        {
            var userDetails = model.Users.Where(x => x.IsDeleted == false).ToList();
            return Task.FromResult(userDetails);
        }
        #endregion

        #region to update the user details by userid
        /// <summary>
        /// to update the user details
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUserDetailsAsync(User users)
        {
            int? userId = users.UserId;
            var user = model.Users.Where(x => x.UserId == userId).FirstOrDefault();
            // null check
            if (user != null)
            {
                user.DateModified = DateTime.Now;
                user.FirstName = users.FirstName;
                user.LastName = users.LastName;
                user.MobileNumber = users.MobileNumber;
                user.Email = users.Email;
                user.Dob = users.Dob;
                await model.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion
    }
}
