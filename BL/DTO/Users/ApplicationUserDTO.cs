using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DTO
{
    /// <summary>
    /// Data Transfer Object(DTO) -> ApplicationUser
    /// This should be used to transfer Events between services.
    /// For Output
    /// </summary>
    public class ApplicationUserDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime Registered { get; set; }
        public bool Active { get; set; }
                
    }
}
