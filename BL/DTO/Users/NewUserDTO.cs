using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.DTO.Users
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
        [MinLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [Compare(nameof(Password))]
        public string PasswordAgain { get; set; }

    }
}
