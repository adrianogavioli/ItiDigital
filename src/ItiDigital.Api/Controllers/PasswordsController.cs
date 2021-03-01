using ItiDigital.Application.Commands;
using ItiDigital.Application.ViewModels;
using ItiDigital.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ItiDigital.Api.Controllers
{
    [Route("password")]
    public class PasswordsController : MainController
    {
        private readonly IMediator _mediator;

        public PasswordsController(Notifier notifier, IMediator mediator) : base(notifier)
        {
            _mediator = mediator;
        }

        [HttpPost("validate")]
        public async Task<ActionResult<bool>> Validate(PasswordViewModel passwordViewModel)
        {
            var result = await _mediator.Send(new PasswordValidateCommand(passwordViewModel));

            return CustomResponse(result);
        }
    }
}
