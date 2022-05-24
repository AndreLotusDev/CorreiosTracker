using CorreioTracker.ConfigHandler;
using Microsoft.AspNetCore.Mvc;

namespace CorreioTracker.SystemHandler
{
    public class TrackerController : Controller
    {
        protected readonly SystemConfigJson _myConfiguration;

        public TrackerController(SystemConfigJson myConfiguration)
        {
            _myConfiguration = myConfiguration;
        }
        public TrackerController()
        {

        }
    }
}
