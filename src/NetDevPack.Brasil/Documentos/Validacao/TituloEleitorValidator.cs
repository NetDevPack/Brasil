using NetDevPack.Utilities;
using System.Collections.Generic;

namespace NetDevPack.Brasil.Documentos.Validacao
{
    public class TituloEleitorValidator
    {
        private const int TamanhoTituloEleitor = 12;
        private readonly string _tituloEleitorTratado;
        private static readonly HashSet<string> _titulosEleitorInvalidos = new HashSet<string>
        {
            "000000000000",
            "111111111111",
            "222222222222",
            "333333333333",
            "444444444444",
            "555555555555",
            "666666666666",
            "777777777777",
            "888888888888",
            "999999999999"
        };

        public TituloEleitorValidator(string numero) => _tituloEleitorTratado = numero.OnlyNumbers();

        public bool EstaValido()
        {
            if (!PossuiTamanhoValido()) return false;
            if (PossuiDigitosRepetidos()) return false;
            return PossuiDigitosValidos();
        }

        private bool PossuiTamanhoValido() => _tituloEleitorTratado.Length == TamanhoTituloEleitor;

        private bool PossuiDigitosRepetidos() => _titulosEleitorInvalidos.Contains(_tituloEleitorTratado);

        private bool PossuiDigitosValidos()
        {
            var primeiraParte = _tituloEleitorTratado.Substring(0, TamanhoTituloEleitor - 4);

            var primeiroDigito = new DigitoVerificador(primeiraParte)
                                        .Modulo(11)
                                        .SemComplementarDoModulo()
                                        .InvertendoNumero()
                                        .HabilitaLimiteModulo(10)
                                        .CalculaDigito();

            var segundaParte = string.Concat(_tituloEleitorTratado.Substring(8, 2), primeiroDigito);

            var segundoDigito = new DigitoVerificador(segundaParte)
                                         .Modulo(11)
                                         .SemComplementarDoModulo()
                                         .InvertendoNumero()
                                         .HabilitaLimiteModulo(10)
                                         .ComMultiplicadoresDeAte(7, 9)
                                         .CalculaDigito();

            return string.Concat(primeiroDigito, segundoDigito) == _tituloEleitorTratado.Substring(TamanhoTituloEleitor - 2, 2);
        }
    }
}
