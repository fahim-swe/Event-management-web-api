using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class PraticipantDto
    {
        public String Email { get; set; } = null!;
        public Boolean IsOrganizer = false;
    }
}