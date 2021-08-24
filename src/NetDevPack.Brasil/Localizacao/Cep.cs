using NetDevPack.Brasil.Localizacao.Validacao;
using NetDevPack.Domain;
using System;

namespace NetDevPack.Brasil.Localizacao
{
    /// <summary>
    /// Representa um CEP (Código de Endereçamento Postal) no Brasil.
    /// </summary>
    public class Cep : IEquatable<Cep>
    {
        /// <summary>
        /// Validador do CEP.
        /// </summary>
        private readonly CepValidador _validador;
        /// <summary>
        /// Formato do CEP.
        /// </summary>
        private const string Formato = @"{0:00000\-000}";
        /// <summary>
        /// Sufixo que indica um CEP genérico.
        /// </summary>
        private const string CepGenerico = "000";

        /// <summary>
        /// O CEP (Código de Endereçamento Postal).
        /// </summary>
        public string Codigo { get; }
        /// <summary>
        /// O prefixo do CEP, os primeiros cinco dígitos.
        /// </summary>
        public string Prefixo { get; private set; }
        /// <summary>
        /// Região do CEP, o primeiro dígito do prefixo.
        /// </summary>
        public char Regiao { get; private set; }
        /// <summary>
        /// Sub-Região do CEP, o segund dígito do prefixo.
        /// </summary>
        public char SubRegiao { get; private set; }
        /// <summary>
        /// Setor do CEP, o terceiro dígito do prefixo.
        /// </summary>
        public char Setor { get; private set; }
        /// <summary>
        /// Subsetor do CEP, o quarto dígito do prefixo.
        /// </summary>
        public char Subsetor { get; private set; }
        /// <summary>
        /// Divisor de subsetor do CEP, o quinto dígito do prefixo.
        /// </summary>
        public char DivisorSubsetor { get; private set; }
        /// <summary>
        /// Sufixo de distribuição do CEP, os últimos três dígitos.
        /// </summary>
        public string Sufixo { get; private set; }

        /// <summary>
        /// Inicializa uma instância da classe <see cref="Cep"/>.
        /// </summary>
        /// <param name="codigo">O CEP (Código de Endereçamento Postal).</param>
        /// <exception cref="DomainException">CEP (Código de Endereçamento Postal) inválido.</exception>
        public Cep(string codigo)
        {
            Codigo = codigo;
            _validador = new CepValidador(codigo);
            if (EstaValido())
                PreencherEstrutura();
        }

        /// <inheritdoc/>
        public override string ToString() => SemMascara();

        /// <summary>
        /// Preenche a estrutura do CEP.
        /// </summary>
        private void PreencherEstrutura()
        {
            Prefixo = Codigo.Substring(0, 5);
            Regiao = Codigo[0];
            SubRegiao = Codigo[1];
            Setor = Codigo[2];
            Subsetor = Codigo[3];
            DivisorSubsetor = Codigo[4];
            Sufixo = Codigo.Substring(Codigo.Length - 3);
        }

        /// <summary>
        /// Recupera o CEP com máscara: XXXXX-XXX.
        /// </summary>
        /// <returns>CEP com máscara: XXXXX-XXX.</returns>
        public string ComMascara()
        {
            if (string.IsNullOrEmpty(Codigo))
            {
                return string.Empty;
            }

            return string.Format(Formato, Convert.ToUInt64(Codigo));
        }

        /// <summary>
        /// Recupera o CEP sem máscara: XXXXXXXX.
        /// </summary>
        /// <returns>CEP sem máscara: XXXXXXXX.</returns>
        public string SemMascara() => Codigo;

        /// <summary>
        /// Verifica se o CEP atende os critérios exigidos.
        /// </summary>
        /// <returns><see cref="true"/> se o CEP atende os critérios exigidos; caso contrário, <see cref="false"/>.</returns>
        public bool EstaValido() => _validador.EstaValido();

        /// <summary>
        /// Verifica se o CEP é genérico ou não. Um CEP digo genérico possui o sufixo "000".
        /// </summary>
        /// <returns><see cref="true"/> se o CEP é genérico; caso contrário, <see cref="false"/>.</returns>
        public bool EhGenerico() => Sufixo == CepGenerico;

        /// <inheritdoc/>
        public bool Equals(Cep other) => Codigo == other.SemMascara();
    }
}
