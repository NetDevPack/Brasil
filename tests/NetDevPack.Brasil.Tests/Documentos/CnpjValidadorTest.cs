using FluentAssertions;
using NetDevPack.Brasil.Documentos;
using NetDevPack.Brasil.Documentos.Validacao;
using NetDevPack.Domain;
using System;
using Xunit;

namespace NetDevPack.Brasil.Tests
{
    public class CnpjValidadorTest
    {
        [Theory(DisplayName = "Cnpj ReturnDomainException")]
        [InlineData("00.000.000/0000-00")]
        [InlineData("11.111.111/1111-11")]
        [InlineData("22.222.222/2222-22")]
        [InlineData("33.333.333/3333-33")]
        [InlineData("44.444.444/4444-44")]
        [InlineData("55.555.555/5555-55")]
        [InlineData("66.666.666/6666-66")]
        [InlineData("77.777.777/7777-77")]
        [InlineData("88.888.888/8888-88")]
        [InlineData("99.999.999/9999-99")]
        [Trait("Category", "Cnpj Tests")]
        public void Cnpj_PossuiDigitosRepetidos_ShouldReturnDomainException(string value)
        {
            // Arrange & Act
            Action act = () => new Cnpj(value);

            // Assert
            act.Should().ThrowExactly<DomainException>().WithMessage("CNPJ Inválido");
        }

        [Fact(DisplayName = "Cnpj ReturnTrue")]
        [Trait("Category", "Cnpj Tests")]
        public void Cnpj_NewCnpj_ShouldReturnNewCnpj()
        {
            // Arrange 
            var cnpj = new Cnpj("30.221.805/0001-26");

            // Act
            var result  = new CnpjValidador(cnpj.Numero).EstaValido();

            // Assert
            result.Should().BeTrue();
        }
    }
}
