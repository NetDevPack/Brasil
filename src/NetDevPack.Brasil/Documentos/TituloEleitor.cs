using NetDevPack.Utilities;
using NetDevPack.Brasil.Documentos.Validacao;

namespace NetDevPack.Brasil.Documentos
{
    public class TituloEleitor
    {
        public string Numero { get; }

        public TituloEleitor(string numero)
        {
            Numero = numero.OnlyNumbers(numero); ;
        }

        public bool EstaValido() => new TituloEleitorValidator(Numero).EstaValido();
    }
}
