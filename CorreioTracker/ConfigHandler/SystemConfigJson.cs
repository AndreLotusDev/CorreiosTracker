using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorreioTracker.ConfigHandler
{
    public class SystemConfigJson
    {
        public EmailBot EmailBot { get; set; }
        public ConnectionsStrings ConnectionsStrings { get; set; }
    }
}
