using ItiDigital.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ItiDigital.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly Notifier _notifier;

        public MainController(Notifier notifier)
        {
            _notifier = notifier;
        }

        protected ActionResult CustomResponse(bool result)
        {
            if (!result)
            {
                return BadRequest(new
                {
                    isValid = false,
                    Errors = _notifier.Notifications.Select(n => n.Message)
                });
            }

            return Ok(new
            {
                isValid = true
            });
        }
    }
}
