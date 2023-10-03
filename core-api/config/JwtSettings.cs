using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_api


{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; } // The issuer of the JWT
        public string Audience { get; set; } // The audience of the JWT
        public int DurationInMinutes { get; set; } // Token expiration duration in minutes

        // You can add other JWT configuration properties here as needed
    }
}
