using ItiDigital.Application.ViewModels;
using MediatR;

namespace ItiDigital.Application.Commands
{
    public class PasswordValidateCommand : IRequest<bool>
    {
        public PasswordViewModel PasswordViewModel { get; private set; }

        public PasswordValidateCommand(PasswordViewModel passwordViewModel)
        {
            PasswordViewModel = passwordViewModel;
        }
    }
}
