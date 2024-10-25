using ByteBank.Common;
using ByteBank.Common.Entities;
using ByteBank.Common.Leitores;
using ByteBank.ConsoleApp;

MostrarBanner();

while (true)
{
    MostrarMenu();

    if (int.TryParse(Console.ReadLine(), out int escolha))
    {
        ExecutarEscolha(escolha);
    }
    else
    {
        Console.WriteLine("Opção inválida. Tente novamente.");
    }
}

static void MostrarBanner()
{
    Console.WriteLine(@"


    ____        __       ____              __      
   / __ )__  __/ /____  / __ )____ _____  / /__    
  / __  / / / / __/ _ \/ __  / __ `/ __ \/ //_/    
 / /_/ / /_/ / /_/  __/ /_/ / /_/ / / / / ,<       
/_____/\__, /\__/\___/_____/\__,_/_/ /_/_/|_|      
      /____/                                       
                                
        ");
}

static void MostrarMenu()
{
    Console.WriteLine("\nEscolha uma opção:");
    Console.WriteLine();
    Console.WriteLine("1. Ler arquivo de boletos");
    Console.WriteLine();
    Console.WriteLine("2. Ler arquivo de boletos por cedente");
    Console.WriteLine();
    Console.Write("Digite o número da opção desejada: ");
}

static void ExecutarEscolha(int escolha)
{
    switch (escolha)
    {
        case 1:
            ConsoleUI.MostrarBoletos("Boletos.csv");
            break;
        // case 2:
        //     var relatorio = new RelatorioDeBoleto(nomeArquivoSaida: "BoletosPorCedente.csv");
        //     relatorio.Processar(LeitorDeBoleto.LerBoletos("Boletos.csv"));

        //     break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}
