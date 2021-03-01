using ItiDigital.Domain.Models;
using ItiDigital.Domain.Validations;
using System.Linq;
using Xunit;

namespace ItiDigital.Domain.Tests
{
    public class PasswordTests
    {
        [Fact(DisplayName ="Validar mínimo nove caracteres (válido)")]
        [Trait("Categoria", "Password - Domain")]
        public void Validar_ContemMinimoNoveCaracteres_DeveRetornarTrue()
        {
            // Arrange
            var password = new Password("Abcd@1234");

            // Act
            var result = password.IsValid;

            // Assert
            Assert.True(result);
            Assert.False(password.ValidationResult.Errors.Any());
        }

        [Fact(DisplayName = "Validar mínimo nove caracteres (inválido)")]
        [Trait("Categoria", "Password - Domain")]
        public void Validar_ContemMinimoNoveCaracteres_DeveRetornarFalse()
        {
            // Arrange
            var password = new Password("Abcd@ 123");

            // Act
            var result = password.IsValid;

            // Assert
            Assert.False(result);
            Assert.Contains(PasswordValidator.MinimoCaracteresMsg, password.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }

        [Fact(DisplayName = "Validar ao menos um dígito (válido)")]
        [Trait("Categoria", "Password - Domain")]
        public void Validar_ContemAoMenosUmDigito_DeveRetornarTrue()
        {
            // Arrange
            var password = new Password("Abcd@1234");

            // Act
            var result = password.IsValid;

            // Assert
            Assert.True(result);
            Assert.False(password.ValidationResult.Errors.Any());
        }

        [Fact(DisplayName = "Validar ao menos um dígito (inválido)")]
        [Trait("Categoria", "Password - Domain")]
        public void Validar_ContemAoMenosUmDigito_DeveRetornarFalse()
        {
            // Arrange
            var password = new Password("Abcd@efgh");

            // Act
            var result = password.IsValid;

            // Assert
            Assert.False(result);
            Assert.Contains(PasswordValidator.ContainsADigitMsg, password.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }

        [Fact(DisplayName = "Validar ao menos uma letra maiúscula (válido)")]
        [Trait("Categoria", "Password - Domain")]
        public void Validar_ContemAoMenosUmaLetraMaiuscula_DeveRetornarTrue()
        {
            // Arrange
            var password = new Password("Abcd@1234");

            // Act
            var result = password.IsValid;

            // Assert
            Assert.True(result);
            Assert.False(password.ValidationResult.Errors.Any());
        }

        [Fact(DisplayName = "Validar ao menos uma letra maiúscula (inválido)")]
        [Trait("Categoria", "Password - Domain")]
        public void Validar_ContemAoMenosUmaLetraMaiuscula_DeveRetornarFalse()
        {
            // Arrange
            var password = new Password("abcd@1234");

            // Act
            var result = password.IsValid;

            // Assert
            Assert.False(result);
            Assert.Contains(PasswordValidator.ContainsAUpperCharMsg, password.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }

        [Fact(DisplayName = "Validar ao menos uma letra minúscula (válido)")]
        [Trait("Categoria", "Password - Domain")]
        public void Validar_ContemAoMenosUmaLetraMinuscula_DeveRetornarTrue()
        {
            // Arrange
            var password = new Password("Abcd@1234");

            // Act
            var result = password.IsValid;

            // Assert
            Assert.True(result);
            Assert.False(password.ValidationResult.Errors.Any());
        }

        [Fact(DisplayName = "Validar ao menos uma letra minúscula (inválido)")]
        [Trait("Categoria", "Password - Domain")]
        public void Validar_ContemAoMenosUmaLetraMinuscula_DeveRetornarFalse()
        {
            // Arrange
            var password = new Password("ABCD@1234");

            // Act
            var result = password.IsValid;

            // Assert
            Assert.False(result);
            Assert.Contains(PasswordValidator.ContainsALowerCharMsg, password.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }

        [Fact(DisplayName = "Validar ao menos um caractere especial (válido)")]
        [Trait("Categoria", "Password - Domain")]
        public void Validar_ContemAoMenosUmCaractereEspecial_DeveRetornarTrue()
        {
            // Arrange
            var password = new Password("Abcd@1234");

            // Act
            var result = password.IsValid;

            // Assert
            Assert.True(result);
            Assert.False(password.ValidationResult.Errors.Any());
        }

        [Fact(DisplayName = "Validar ao menos um caractere especial (inválido)")]
        [Trait("Categoria", "Password - Domain")]
        public void Validar_ContemAoMenosUmCaractereEspecial_DeveRetornarFalse()
        {
            // Arrange
            var password = new Password("Abcd01234");

            // Act
            var result = password.IsValid;

            // Assert
            Assert.False(result);
            Assert.Contains(PasswordValidator.ContainsASpecialCharMsg, password.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }

        [Fact(DisplayName = "Validar não possuir caracteres repetidos (válido)")]
        [Trait("Categoria", "Password - Domain")]
        public void Validar_NaoPossuirCaracteresRepetidos_DeveRetornarTrue()
        {
            // Arrange
            var password = new Password("Abcd@1234");

            // Act
            var result = password.IsValid;

            // Assert
            Assert.True(result);
            Assert.False(password.ValidationResult.Errors.Any());
        }

        [Fact(DisplayName = "Validar não possuir caracteres repetidos (inválido)")]
        [Trait("Categoria", "Password - Domain")]
        public void Validar_NaoPossuirCaracteresRepetidos_DeveRetornarFalse()
        {
            // Arrange
            var password = new Password("Abcd@123A");

            // Act
            var result = password.IsValid;

            // Assert
            Assert.False(result);
            Assert.Contains(PasswordValidator.NotContainDuplicatedCharMsg, password.ValidationResult.Errors.Select(e => e.ErrorMessage));
        }
    }
}
