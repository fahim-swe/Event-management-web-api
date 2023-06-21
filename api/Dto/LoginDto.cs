using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class LoginDto
    {
      
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "The Password field is required.")]
        [MinLength(6, ErrorMessage = "The Password field must be at least 6 characters long.")]
        public string Password { get; set; } = null!;
    }
}