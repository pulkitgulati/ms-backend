using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationMicroservice.DTO
{
    public class UserDetails
    {
        public string displayName { get; set; } = string.Empty;
        public string userName { get; set; } = string.Empty;
        public string Authorization { get; set; } = string.Empty;
        

    }
}
