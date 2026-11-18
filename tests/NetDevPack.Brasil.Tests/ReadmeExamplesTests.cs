using AwesomeAssertions;
using NetDevPack.Brasil.Documentos;
using NetDevPack.Brasil.Localizacao;
using Xunit;

namespace NetDevPack.Brasil.Tests
{
    /// <summary>
    /// Keeps the examples in README.md honest.
    /// </summary>
    public class ReadmeExamplesTests
    {
        [Fact(DisplayName = "README examples")]
        [Trait("Category", "Readme")]
        public void ReadmeExamples_ShouldWorkAsDocumented()
        {
            var cpf = new Cpf("915.212.540-87");
            cpf.SemMascara().Should().Be("91521254087");
            cpf.ComMascara().Should().Be("915.212.540-87");

            var cnpj = new Cnpj("11.444.777/0001-61");
            cnpj.ComMascara().Should().Be("11.444.777/0001-61");

            var titulo = new TituloEleitor("1023 8501 0671");
            titulo.EstaValido().Should().BeTrue();

            var cep = new Cep("01310-100");
            cep.EstaValido().Should().BeTrue();
            cep.ComMascara().Should().Be("01310-100");
        }
    }
}
