using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO
{
    public class NewUserDTO
    {
        [Required]
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(1024,ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        

        [Required]
        [Compare(nameof(Password))]
        public string PasswordAgain { get; set; }

    }
}
