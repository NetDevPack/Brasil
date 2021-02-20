using NetDevPack.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetDevPack.Brasil.Documentos.Validacao
{
    public class TituloEleitorValidator
    {
        private const int TamanhoTituloEleitor = 12;
        private readonly string _tituloEleitorTratado;

        public TituloEleitorValidator(string numero) => _tituloEleitorTratado = numero.OnlyNumbers(numero);

        public bool EstaValido()
        {
            if (!PossuiTamanhoValido()) return false;
            if (PossuiDigitosRepetidos()) return false;            
            return PossuiDigitosValidos();
        }

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

        private bool PossuiDigitosRepetidos()
        {
            var titulosEleitorInvalidos = new List<string>()
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

            return titulosEleitorInvalidos.Contains(_tituloEleitorTratado);
        }

        private bool PossuiTamanhoValido() => _tituloEleitorTratado.Length == TamanhoTituloEleitor;
    }
}
