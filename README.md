<img src="https://repository-images.githubusercontent.com/269783213/ded11000-a765-11ea-8590-6ed700685675" alt=".NET DevPack" width="300px" />

O que é o .NET DevPack Brasil?
=====================
Uma coleção de utilidades para o Brasil: documentos nacionais (CPF, CNPJ, Título de Eleitor) e CEP, com validação e formatação. Foi feito para ser usado junto com o [NetDevPack](https://github.com/NetDevPack/NetDevPack).

## Dê uma estrela! :star:
Se você gostou do projeto ou se o NetDevPack te ajudou, deixe uma estrela ;)

## Como começar

```
dotnet add package NetDevPack.Brasil
```

| Pacote | Versão | Downloads |
| ------ | ------ | --------- |
| `NetDevPack.Brasil` | [![NuGet](https://img.shields.io/nuget/v/NetDevPack.Brasil.svg)](https://nuget.org/packages/NetDevPack.Brasil) | [![Nuget](https://img.shields.io/nuget/dt/NetDevPack.Brasil.svg)](https://nuget.org/packages/NetDevPack.Brasil) |

### Compatibilidade

| Versão | Target framework | NetDevPack |
| ------ | ---------------- | ---------- |
| 3.x    | .NET 10 (LTS)    | 9.x |
| 2.x    | .NET Standard 2.1, .NET 8, 9 e 10 | 8.x |

## Exemplos

Os construtores validam o valor e lançam `NetDevPack.Domain.DomainException` quando ele é inválido. Máscara e caracteres não numéricos são ignorados.

```csharp
using NetDevPack.Brasil.Documentos;
using NetDevPack.Brasil.Localizacao;

var cpf = new Cpf("915.212.540-87");
cpf.SemMascara();   // "91521254087"
cpf.ComMascara();   // "915.212.540-87"

var cnpj = new Cnpj("11.444.777/0001-61");
cnpj.ComMascara();  // "11.444.777/0001-61"

var titulo = new TituloEleitor("1023 8501 0671");

var cep = new Cep("01310-100");
cep.EstaValido();   // true
cep.ComMascara();   // "01310-100"
```

Também dá para validar sem criar o objeto, com `CpfValidador`, `CnpjValidador` e `TituloEleitorValidator` (namespace `NetDevPack.Brasil.Documentos.Validacao`) e `CepValidador` (`NetDevPack.Brasil.Localizacao.Validacao`).

## Sobre
O .NET DevPack Brasil foi desenvolvido por [Eduardo Pires](http://eduardopires.net.br) sob a [licença MIT](LICENSE).
