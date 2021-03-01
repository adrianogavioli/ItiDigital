using FluentValidation;
using ItiDigital.Domain.Models;
using System.Linq;

namespace ItiDigital.Domain.Validations
{
    public class PasswordValidator : AbstractValidator<Password>
    {
        public static string MinimoCaracteresMsg => $"A senha deve ter no mínimo {Password.MinLength} caracteres, desconsiderando espaços em branco.";
        public static string ContainsADigitMsg => "A senha deve conter ao menos um número.";
        public static string ContainsAUpperCharMsg => "A senha deve conter ao menos uma letra maiúscula.";
        public static string ContainsALowerCharMsg => "A senha deve conter ao menos uma letra minúscula.";
        public static string ContainsASpecialCharMsg => $"A senha deve conter ao menos um desses caracteres especiais ({Password.SpecialChars}).";
        public static string NotContainDuplicatedCharMsg => $"A senha não deve possuir caracteres duplicados.";

        public PasswordValidator()
        {
            RuleFor(p => p.Value)
                .MinimumLength(Password.MinLength).WithMessage(MinimoCaracteresMsg);

            RuleFor(p => p.Value)
                .Must(ContainsADigit).WithMessage(ContainsADigitMsg);

            RuleFor(p => p.Value)
                .Must(ContainsAUpperChar).WithMessage(ContainsAUpperCharMsg);

            RuleFor(p => p.Value)
                .Must(ContainsALowerChar).WithMessage(ContainsALowerCharMsg);

            RuleFor(p => p.Value)
                .Must(ContainsASpecialChar).WithMessage(ContainsASpecialCharMsg);

            RuleFor(p => p.Value)
                .Must(NotContainDuplicatedChar).WithMessage(NotContainDuplicatedCharMsg);
        }

        private bool ContainsADigit(string value) => value.Any(char.IsDigit);

        private bool ContainsAUpperChar(string value) => value.Any(char.IsUpper);

        private bool ContainsALowerChar(string value) => value.Any(char.IsLower);

        private bool ContainsASpecialChar(string value) => value.Any(Password.SpecialChars.Contains);

        private bool NotContainDuplicatedChar(string value) => value.Distinct().Count() == value.Length;
    }
}
