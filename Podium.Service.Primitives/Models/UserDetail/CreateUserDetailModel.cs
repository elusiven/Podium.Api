using System;
using System.ComponentModel.DataAnnotations;

namespace Podium.Service.Primitives.Models.UserDetail
{
    public class CreateUserDetailModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}