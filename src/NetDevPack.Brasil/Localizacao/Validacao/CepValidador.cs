using NetDevPack.Utilities;
using System.Text.RegularExpressions;

namespace NetDevPack.Brasil.Localizacao.Validacao
{
    /// <summary>
    /// Aplica validações referentes a um CEP (Código de Endereçamento Postal) no Brasil.
    /// </summary>
    public class CepValidador
    {
        /// <summary>
        /// Tamanho do CEP.
        /// <summary>
        private const int TamanhoCep = 8;
        /// <summary>
        /// Armazena apenas os dígitos do CEP.
        /// </summary>
        private readonly string _cepTratado;

        private readonly string _cepOriginal;

        private readonly Regex _formatoEsperado = new Regex(@"^(\d{5}-\d{3})|(\d{8})$", RegexOptions.Compiled);

        /// <summary>
        /// Inicializa uma instância da classe <see cref="CepValidador"/>.
        /// </summary>
        /// <param name="codigo">O CEP (Código de Endereçamento Postal).</param>
        public CepValidador(string codigo)
        {
            _cepTratado = codigo.OnlyNumbers();
            _cepOriginal = codigo;
        }

        /// <summary>
        /// Verifica se o CEP atende o critério de tamanho definido.
        /// </summary>
        /// <returns><see cref="true"/> se o CEP atende o critério de tamanho definido; caso contrário, <see cref="false"/>.</returns>
        public bool EstaValido()
        {
            return PossuiTamanhoValido() && _formatoEsperado.IsMatch(_cepOriginal);
        }

        /// <summary>
        /// Indica se o CEP possui um tamanho válido ou não.
        /// </summary>
        /// <returns><see cref="true"/> se é um CEP válido; caso contrário, <see cref="false"/>.</returns>
        private bool PossuiTamanhoValido() => _cepTratado.Length == TamanhoCep;
    }
}
