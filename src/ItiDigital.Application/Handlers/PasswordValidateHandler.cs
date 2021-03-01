using AutoMapper;
using ItiDigital.Application.Commands;
using ItiDigital.Core.Notifications;
using ItiDigital.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ItiDigital.Application.Handlers
{
    public class PasswordValidateHandler : IRequestHandler<PasswordValidateCommand, bool>
    {
        private readonly Notifier _notifier;
        private readonly IMapper _mapper;

        public PasswordValidateHandler(
            Notifier notifier,
            IMapper mapper)
        {
            _notifier = notifier;
            _mapper = mapper;
        }

        public Task<bool> Handle(PasswordValidateCommand request, CancellationToken cancellationToken)
        {
            var password = _mapper.Map<Password>(request.PasswordViewModel);

            if (!password.IsValid)
            {
                _notifier.AddNotifications(password.ValidationResult);
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}
