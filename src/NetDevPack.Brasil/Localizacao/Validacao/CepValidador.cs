using NetDevPack.Utilities;

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

        /// <summary>
        /// Inicializa uma instância da classe <see cref="CepValidador"/>.
        /// </summary>
        /// <param name="codigo">O CEP (Código de Endereçamento Postal).</param>
        public CepValidador(string codigo) => _cepTratado = codigo.OnlyNumbers(codigo);

        /// <summary>
        /// Verifica se o CEP atende o critério de tamanho definido.
        /// </summary>
        /// <returns><see cref="true"/> se o CEP atende o critério de tamanho definido; caso contrário, <see cref="false"/>.</returns>
        public bool EstaValido()
        {
            return PossuiTamanhoValido();
        }

        /// <summary>
        /// Indica se o CEP possui um tamanho válido ou não.
        /// </summary>
        /// <returns><see cref="true"/> se é um CEP válido; caso contrário, <see cref="false"/>.</returns>
        private bool PossuiTamanhoValido() => _cepTratado.Length == TamanhoCep;
    }
}
