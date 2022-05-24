using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorreioTracker.DomainModels
{
    public class TrackingModel
    {
        public string Codigo { get; set; }
        public List<string> Attualizations { get; set; }
    }
}
