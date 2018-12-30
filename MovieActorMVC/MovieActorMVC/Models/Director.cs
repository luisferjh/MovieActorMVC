using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieActorMVC.Models
{
    public class Director
    {
        public int DirectorId { get; set; }

        public string FirtsName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public List<MovieDirector> MovieDirector { get; set; }
    }
}
