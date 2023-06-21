using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace model.Entities
{
    public class User : BaseEntity
    {
        public String Name {get; set;} = null!;

        [EmailAddress]
        public String Email {get; set;} = null!;


        public Byte[] PasswordHash {get;set;} = null;
        public Byte[] PasswordSalt {get;set;} = null;


        public List<EventParticipant> EventParticipants {get; set;} = null;
        public List<Event>? Events {get; set;} = null;
    }
}