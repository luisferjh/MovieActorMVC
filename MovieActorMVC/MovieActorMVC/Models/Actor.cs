using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieActorMVC.Models
{
    public class Actor
    {
        public int ActorId { get; set; }

        public string FirtsName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public List<MovieActor> MovieActor { get; set; }
    }
}
