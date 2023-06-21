

using System.ComponentModel.DataAnnotations;

namespace jwtAuth.Model
{
    public class UserDto 
    {
        public Guid Id {get;set;}
        public String Name {get; set;} = null!;

        [EmailAddress]
        public String Email {get; set;} = null!;
    }
}