using FluentValidation;
using FluentValidation.Results;

namespace ItiDigital.Core.DomainObjects
{
    public abstract class ValueObject
    {
        public bool IsValid { get; private set; }

        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return IsValid = ValidationResult.IsValid;
        }
    }
}
