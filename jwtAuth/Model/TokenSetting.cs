using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwtAuth.Model
{
    public class TokenSetting
    {
        public string ValidAudience {get; set;} = null!;
        public string ValidIssuer {get;set;} = null!;
        public string Secret {get;set;} = null!;
        public string TokenValidityInMinutes {get;set;} = null!;
        public string RefreshTokenValidityInDays {get;set;} = null!;
    }
}