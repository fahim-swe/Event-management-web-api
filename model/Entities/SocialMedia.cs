using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace model.Entities
{
    public class SocialMedia : BaseEntity
    {
        public String Link {get;set;} = null;
        public String Name {get;set;} = null!;

        public Event Event {get;set;} = null!;

    }
}