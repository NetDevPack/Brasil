using System;
using NetDevPack.Domain;
using NetDevPack.Utilities;
using NetDevPack.Brasil.Documentos.Validacao;

namespace NetDevPack.Brasil.Documentos
{
    public class Cnpj
    {
        public string Numero { get; }

        public Cnpj(string numero)
        {
            Numero = numero.OnlyNumbers(numero);
            if (!EstaValido()) throw new DomainException("CNPJ Inválido");
        }

        public override string ToString() => SemMascara();

        public string ComMascara()
        {
            if (string.IsNullOrEmpty(Numero))
                return string.Empty;

            const string pattern = @"{0:00\.000\.000\/0000\-00}";
            return string.Format(pattern, Convert.ToUInt64(Numero));
        }

        public string SemMascara() => Numero;

        public bool EstaValido() => new CnpjValidador(Numero).EstaValido();

        public bool Equals(Cnpj cnpj) => Numero == cnpj.SemMascara();
    }
}