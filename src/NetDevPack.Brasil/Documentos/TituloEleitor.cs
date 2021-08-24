using NetDevPack.Utilities;
using NetDevPack.Brasil.Documentos.Validacao;
using NetDevPack.Domain;

namespace NetDevPack.Brasil.Documentos
{
    public class TituloEleitor
    {
        public string Numero { get; }

        public TituloEleitor(string numero)
        {
            Numero = numero.OnlyNumbers();
            if (!EstaValido()) throw new DomainException("TituloEleitor Invalido");
        }

        public bool EstaValido() => new TituloEleitorValidator(Numero).EstaValido();
    }
}
