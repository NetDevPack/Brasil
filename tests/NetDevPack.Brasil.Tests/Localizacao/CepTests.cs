using FluentAssertions;
using NetDevPack.Brasil.Localizacao;
using Xunit;

namespace NetDevPack.Brasil.Tests.Localizacao
{
    public class CepTests
    {

        [Theory]
        [InlineData("87970-000")]
        [InlineData("86039-215")]
        [InlineData("01000-000")]
        [InlineData("01000000")]
        [InlineData("87970000")]
        [InlineData("86039215")]
        public void Should_Validate_Ceps(string codigo)
        {
            var cep = new Cep(codigo);
            cep.EstaValido().Should().BeTrue();
        }

        [Theory]
        [InlineData("87970O00")]
        [InlineData("860321o5")]
        [InlineData("0100000")]
        [InlineData("01-00000")]
        [InlineData("879aoe700^0-0")]
        [InlineData("8603a9215")]
        public void Should_Not_Validate_Ceps(string codigo)
        {
            var cep = new Cep(codigo);
            cep.EstaValido().Should().BeFalse();
        }
    }
}
