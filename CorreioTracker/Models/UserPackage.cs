using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorreioTracker.Models
{
    public class UserPackage
    {
        public int IdUser { get; set; }
        public User User { get; set; }

        public int Id { get; set; }
        public string PackageNumber { get; set; }
        public int NumberOfMovments { get; set; }
        public DateTime LastAtualization { get; set; }
    }
}
