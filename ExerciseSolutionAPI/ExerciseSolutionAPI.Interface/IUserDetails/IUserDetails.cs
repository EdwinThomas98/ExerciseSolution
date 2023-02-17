using ExerciseSolutionAPI.Repository.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExerciseSolutionAPI.Interface.IUserDetails
{
    public interface IUserDetails
    {
        Task<List<User>> GetUserDetailsAsync();
        Task<bool> CreateUserDetailsAsync(User users);
        Task<bool> UpdateUserDetailsAsync(User users);
        Task<bool> DeleteUserDetailsAsync(User users);
    }
}
