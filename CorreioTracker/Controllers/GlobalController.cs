using CorreioTracker.ConfigHandler;
using CorreioTracker.Helpers;
using CorreioTracker.SystemHandler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CorreioTracker.DomainModels;

namespace CorreioTracker.Controllers
{
    public class GlobalController : TrackerController
    {
        private readonly ILogger<GlobalController> _logger;

        public GlobalController(SystemConfigJson systemConfigJson, ILogger<GlobalController> logger) : base(systemConfigJson)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult SentMessage(EmailSentModel model)
        {
            try
            {
                EmailBot bot = _myConfiguration.EmailBot;

                model.Address = model.Address.Trim();
                model.Body = model.Body.Trim();
                model.Subject = model.Subject.Trim();

                EmailBuilder mailB = new EmailBuilder(model, bot, true);
                mailB.ConfigureEmailServicePartnership();

                return Ok();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
