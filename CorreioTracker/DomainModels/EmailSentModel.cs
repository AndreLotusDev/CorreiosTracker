using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorreioTracker.DomainModels
{
    public class EmailSentModel
    {
        public string Address { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
