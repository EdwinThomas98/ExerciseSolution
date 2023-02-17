using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseSolutionAPI.Repository.Users
{
    public class User
    {
        [Key]
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
        public string MobileNumber { get; set; }
        public bool IsDeleted { get; set; }
        public string Email { get; set; }
        public DateTime? Dob { get; set; }
    }
}
