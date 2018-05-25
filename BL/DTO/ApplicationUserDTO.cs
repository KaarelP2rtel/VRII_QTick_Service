using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DTO
{
    public class ApplicationUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Registered { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }

        
    }
}
