using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DTO
{
    public class ApplicationUserDTO
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime Registered { get; set; }
        public bool Active { get; set; }
        

        
    }
}
