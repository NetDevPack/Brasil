using FluentAssertions;
using NetDevPack.Brasil.Documentos;
using NetDevPack.Brasil.Documentos.Validacao;
using NetDevPack.Domain;
using System;
using Xunit;

namespace NetDevPack.Brasil.Tests
{
    public class CpfValidadorTest
    {
        [Theory(DisplayName = "Cpf ReturnDomainException")]
        [InlineData("000.000.000-00")]
        [InlineData("111.111.111-11")]
        [InlineData("222.222.222-22")]
        [InlineData("333.333.333-33")]
        [InlineData("444.444.444-44")]
        [InlineData("555.555.555-55")]
        [InlineData("666.666.666-66")]
        [InlineData("777.777.777-77")]
        [InlineData("888.888.888-88")]
        [InlineData("999.999.999-99")]
        [Trait("Category", "Cpf Tests")]
        public void Cpf_PossuiDigitosRepetidos_ShouldReturnDomainException(string value)
        {
            // Arrange & Act
            Action act = () => new Cpf(value);

            // Assert
            act.Should().ThrowExactly<DomainException>().WithMessage("CPF Invalido");
        }

        [Fact(DisplayName = "Cpf ReturnTrue")]
        [Trait("Category", "Cpf Tests")]
        public void Cpf_NewCpf_ShouldReturnNewCpf()
        {
            // Arrange 
            var cpf = new Cpf("915.212.540-87");

            // Act
            var result = new CpfValidador(cpf.Numero).EstaValido();

            // Assert
            result.Should().BeTrue();
        }
    }
}
