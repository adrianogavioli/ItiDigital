using ItiDigital.Core.DomainObjects;
using ItiDigital.Domain.Validations;

namespace ItiDigital.Domain.Models
{
    public class Password : ValueObject
    {
        public static int MinLength = 9;
        public static string SpecialChars = "!@#$%^&*()-+";

        public string Value { get; private set; }

        public Password(string value)
        {
            Value = value.Replace(" ", string.Empty);

            Validate(this, new PasswordValidator());
        }
    }
}
