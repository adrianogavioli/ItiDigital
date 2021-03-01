using AutoMapper;
using ItiDigital.Application.ViewModels;
using ItiDigital.Domain.Models;

namespace ItiDigital.Application.AutoMapper
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<Password, PasswordViewModel>();
        }
    }
}
