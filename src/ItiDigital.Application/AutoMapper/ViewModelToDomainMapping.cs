using AutoMapper;
using ItiDigital.Application.ViewModels;
using ItiDigital.Domain.Models;

namespace ItiDigital.Application.AutoMapper
{
    public class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<PasswordViewModel, Password>()
                .ConstructUsing(v => new Password(v.Value));
        }
    }
}
