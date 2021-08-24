using System;
using FluentAssertions;
using NetDevPack.Brasil.Documentos;
using NetDevPack.Brasil.Documentos.Validacao;
using NetDevPack.Domain;
using Xunit;

namespace NetDevPack.Brasil.Tests.Documentos
{
    public class TituloEleitorValidadorTest
    {
        [Theory(DisplayName = "TituloEleitor ReturnDomainException")]
        [InlineData("000000000000")]
        [InlineData("1111 1111 1111")]
        [InlineData("2222 2222 2222")]
        [InlineData("3333 3333 3333")]
        [InlineData("4444 4444 4444")]
        [InlineData("5555 5555 5555")]
        [InlineData("6666 6666 6666")]
        [InlineData("7777 7777 7777")]
        [InlineData("8888 8888 8888")]
        [InlineData("9999 9999 9999")]
        [InlineData("456123456789")]
        [InlineData("456123456789022")]
        [InlineData("258365200125")]
        [InlineData("002365896322")]
        [InlineData("147258369789")]
        [Trait("Category", "TituloEleitor Tests")]
        public void TituloEleitor_PossuiDigitosRepetidos_ShouldReturnDomainException(string value)
        {
            // Arrange & Act
            Action act = () => new TituloEleitor(value);

            // Assert
            act.Should().ThrowExactly<DomainException>().WithMessage("TituloEleitor Invalido");
        }

        [Theory(DisplayName = "TituloEleitor ReturnTrue")]
        [InlineData("007378060183")]
        [InlineData("304083450132")]
        [InlineData("223644070124")]
        [InlineData("8018 6038 0159")]
        [InlineData("7542 4177 0175")]
        [InlineData("8720 0766 0191")]
        [InlineData("6311 6330 1414")]
        [InlineData("874726180620")]
        [InlineData("067106681546")]
        [InlineData("313246081040")]
        [Trait("Category", "TituloEleitor Tests")]
        public void TituloEleitor_NewTituloEleitor_ShouldReturnTrue(string value)
        {
            // Arrange 
            var tituloEleitor = new TituloEleitor(value);

            // Act
            var result = new TituloEleitorValidator(tituloEleitor.Numero).EstaValido();

            // Assert
            result.Should().BeTrue();
        }
    }
}
